import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import DataBaseType from '@/components/DataBaseType'
import DataBaseTypeEdit from '@/components/DataBaseType.Edit'
import DatabaseItem from '@/components/DatabaseItem'
import DatabaseItemEdit from '@/components/DatabaseItem.Edit'

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
    }, {
      path: '/database/item',
      name: 'Database Item',
      component: DatabaseItem
    }, {
      path: '/database/item/:mode',
      name: 'Edit Database Item',
      component: DatabaseItemEdit
    }
  ]
})
