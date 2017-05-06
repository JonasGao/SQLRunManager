<template>
  <div>
    <h4>Database Type</h4>
    <hr>
    <button type="button" @click="createDatabaseType()">新建</button>
    <table class="table">
      <thead>
      <tr>
        <th>Title</th>
        <th>Server</th>
        <th>Port</th>
        <th>Uid</th>
        <th>Pwd</th>
        <th>Created</th>
        <th>Creater</th>
        <th></th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="databaseType in databaseTypes">
        <td>{{ databaseType.title }}</td>
        <td>{{ databaseType.server }}</td>
        <td>{{ databaseType.port }}</td>
        <td>{{ databaseType.uid }}</td>
        <td>{{ databaseType.pwd }}</td>
        <td>{{ databaseType.created }}</td>
        <td>{{ databaseType.creater }}</td>
        <td>
          <button type="button" @click="editDatabaseType(databaseType)">编辑</button>
          <button type="button" @click="deleteDatabaseType(databaseType)">删除</button>
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
    name: 'databaseType',
    created () {
      this.getDatabaseTypes()
    },
    computed: {
      ...mapState({
        databaseTypes: state => state.moduleDatabaseType.list
      })
    },
    methods: {
      ...mapMutations([
        'setDatabaseType'
      ]),
      ...mapActions([
        'deleteDatabaseType',
        'getDatabaseTypes'
      ]),
      createDatabaseType () {
        this.setDatabaseType({})
        router.push('/database/type/create')
      },
      editDatabaseType (databaseType) {
        this.setDatabaseType(databaseType)
        router.push('/database/type/edit')
      }
    }
  }
</script>
