import Vue from 'vue'
import Vuex from 'vuex'
import moduleDatabaseType from './store.databaseType'
import moduleDatabaseItem from './store.databaseItem'

Vue.use(Vuex)

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  modules: {
    moduleDatabaseType,
    moduleDatabaseItem
  }
})
