<template>
  <div>
    <h4>Database Item</h4>
    <hr>
    <button type="button" @click="createDatabaseItem()">新建</button>
    <table class="table">
      <thead>
      <tr>
        <th>Title</th>
        <th>Server</th>
        <th>Port</th>
        <th>Uid</th>
        <th>Pwd</th>
        <th>Removed</th>
        <th>Created</th>
        <th>Creater</th>
        <th></th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="databaseItem in databaseItems">
        <td>{{ databaseItem.title }}</td>
        <td>{{ databaseItem.server }}</td>
        <td>{{ databaseItem.port }}</td>
        <td>{{ databaseItem.uid }}</td>
        <td>{{ databaseItem.pwd }}</td>
        <td>{{ databaseItem.removed }}</td>
        <td>{{ databaseItem.created }}</td>
        <td>{{ databaseItem.creater }}</td>
        <td>
          <template v-if="!databaseItem.removed">
            <button type="button" @click="editDatabaseItem(databaseItem)">编辑</button>
            <button type="button" @click="deleteDatabaseItem(databaseItem)">删除</button>
          </template>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  import router from '../router'
  import { mapMutations, mapState, mapActions } from 'vuex'

  export default {
    name: 'current',
    created () {
      this.getDatabaseItems()
    },
    computed: {
      ...mapState({
        databaseItems: state => state.moduleDatabaseItem.list
      })
    },
    methods: {
      ...mapMutations([
        'setDatabaseItem',
        'setDatabaseItems',
        'deleteDatabaseType'
      ]),
      ...mapActions([
        'getDatabaseItems',
        'deleteDatabaseItem'
      ]),
      createDatabaseItem () {
        this.setDatabaseItem({})
        router.push('/database/item/create')
      },
      editDatabaseItem (databaseItem) {
        this.setDatabaseItem(databaseItem)
        router.push('/database/item/edit')
      }
    }
  }
</script>
