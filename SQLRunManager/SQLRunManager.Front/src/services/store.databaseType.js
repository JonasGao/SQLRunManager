import { assign } from 'lodash'
import { rest } from './rest'

const resources = rest('databaseType')

export default {
  state: {
    list: [],
    current: {}
  },
  mutations: {
    setDatabaseTypes (state, databaseTypes) {
      state.list = databaseTypes
    },
    setDatabaseType (state, databaseType) {
      state.current = databaseType
    },
    pushDatabaseType (state, databaseType) {
      state.list.push(databaseType)
    },
    putDatabaseType (state, databaseType) {
      assign(state.current, databaseType)
    },
    deleteDatabaseType (state, databaseType) {
      state.list.splice(state.list.indexOf(databaseType), 1)
    }
  },
  actions: {
    async putDatabaseType (context, databaseType) {
      const list = context.state.list
      const storedType = context.state.current

      if (list.indexOf(storedType) < 0) {
        const [data] = await resources.push(databaseType)
        databaseType.id = data.id
        context.commit('pushDatabaseType', databaseType)
        return
      }

      await resources.put(databaseType)
      context.commit('putDatabaseType', databaseType)
    },
    async deleteDatabaseType (context, databaseType) {
      resources.del(databaseType)
      context.commit('deleteDatabaseType', databaseType)
    },
    async getDatabaseTypes (context) {
      let list = context.state.list
      if (!list.length) {
        const [data] = await resources.get()
        context.commit('setDatabaseTypes', list = data)
      }
      return list
    }
  }
}
