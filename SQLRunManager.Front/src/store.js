import Vue from 'vue'
import Vuex from 'vuex'
import _ from 'lodash'

Vue.use(Vuex)

const session = {
  get databaseTypes () {
    let databaseTypes = sessionStorage.getItem('databaseTypes')
    if (databaseTypes) {
      databaseTypes = JSON.parse(databaseTypes)
    }
    if (!databaseTypes || !(databaseTypes instanceof Array)) {
      databaseTypes = []
    }
    return databaseTypes
  },
  set databaseTypes (data) {
    sessionStorage.setItem('databaseTypes', JSON.stringify(data))
  }
}

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state: {
    databaseTypes: session.databaseTypes,
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
      session.databaseTypes = state.databaseTypes = databaseTypes
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
    }
  }
})
