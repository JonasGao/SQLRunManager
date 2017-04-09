import Vue from 'vue'
import Vuex from 'vuex'
import _ from 'lodash'

Vue.use(Vuex)

function defaultDatabaseTypes () {
  let databaseTypes = sessionStorage.getItem('databaseTypes')
  if (databaseTypes) {
    databaseTypes = JSON.parse(databaseTypes)
  }
  if (!databaseTypes || !(databaseTypes instanceof Array)) {
    databaseTypes = []
  }
  return databaseTypes
}

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state: {
    databaseTypes: defaultDatabaseTypes(),
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
      state.databaseTypes.push(databaseType)
    }
  }
})
