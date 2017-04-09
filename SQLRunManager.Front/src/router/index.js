import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import DataBaseType from '@/components/DataBaseType'
import DataBaseTypeEdit from '@/components/DataBaseType.Edit'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    }, {
      path: '/database/type',
      name: 'Database Type',
      component: DataBaseType
    }, {
      path: '/database/type/:mode',
      name: 'Edit Database Type',
      component: DataBaseTypeEdit
    }
  ]
})
