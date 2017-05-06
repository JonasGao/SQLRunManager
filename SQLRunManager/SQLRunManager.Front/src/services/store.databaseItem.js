import { assign } from 'lodash'
import { rest } from './rest'

const resources = rest('databaseItem')

export default {
  state: {
    list: [],
    current: {}
  },
  mutations: {
    setDatabaseItems (state, databaseItems) {
      state.list = databaseItems
    },
    setDatabaseItem (state, databaseItem) {
      state.current = databaseItem
    },
    pushDatabaseItem (state, databaseItem) {
      state.list.push(databaseItem)
    },
    putDatabaseItem (state, databaseItem) {
      assign(state.current, databaseItem)
    },
    removeDatabaseItem (state, databaseItem) {
      state.list.splice(state.list.indexOf(databaseItem), 1)
    }
  },
  actions: {
    async getDatabaseItems (context) {
      let list = context.state.list
      if (!list.length) {
        const [data] = await resources.get()
        context.commit('setDatabaseItems', list = data)
      }
      return list
    },
    async putDatabaseItem (context, databaseItem) {
      const list = context.state.list
      if (list.indexOf(context.state.current) < 0) {
        const [data] = await resources.post(databaseItem)
        context.commit('pushDatabaseItem', data)
      } else {
        await resources.put(databaseItem)
        context.commit('putDatabaseItem', databaseItem)
      }
    },
    async deleteDatabaseItem (context, databaseItem) {
      await resources.del(databaseItem)
      context.commit('removeDatabaseItem', databaseItem)
    }
  }
}
