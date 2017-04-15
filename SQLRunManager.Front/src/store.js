import Vue from 'vue'
import Vuex from 'vuex'
import _ from 'lodash'

Vue.use(Vuex)

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state: {
    databaseTypes: [],
    databaseType: {}
  },
  getters: {
    databaseType (state) {
      return _.clone(state.databaseType)
    },
    databaseTypes (state) {
      return state.databaseTypes
    }
  },
  mutations: {
    setDatabaseTypes (state, databaseTypes) {
      state.databaseTypes = databaseTypes
    },
    setCurrentDatabaseType (state, databaseType) {
      state.databaseType = databaseType
    },
    pushDatabaseType (state, databaseType) {
      if (state.databaseTypes.indexOf(state.databaseType) < 0) {
        state.databaseTypes.push(databaseType)
        return
      }
      _.assign(state.databaseType, databaseType)
    },
    deleteDatabaseType (state, databaseType) {
      state.databaseTypes.splice(state.databaseTypes.indexOf(databaseType), 1)
    }
  }
})
