<template>
  <div>
    <h4>Database Type</h4>
    <hr>
    <button type="button" @click="createDatabaseType()">新建</button>
    <table class="table table-info">
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
          <button type="button" @click="del(databaseType)">删除</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  import router from '../router'
  import rest from '../services/rest'
  import {mapMutations, mapGetters} from 'vuex'

  export default {
    name: 'databaseType',
    created () {
      this.loadDatabaseTypes()
    },
    computed: {
      ...mapGetters([
        'databaseTypes'
      ])
    },
    methods: {
      ...mapMutations([
        'setCurrentDatabaseType',
        'setDatabaseTypes',
        'deleteDatabaseType'
      ]),
      async getDatabaseTypes () {
        const [data] = await rest('databaseType').get()
        return data
      },
      async loadDatabaseTypes () {
        if (!this.databaseTypes || !this.databaseTypes.length) {
          this.setDatabaseTypes(await this.getDatabaseTypes())
        }
      },
      createDatabaseType () {
        this.setCurrentDatabaseType({})
        router.push('/database/type/create')
      },
      editDatabaseType (databaseType) {
        this.setCurrentDatabaseType(databaseType)
        router.push('/database/type/edit')
      },
      async del (databaseType) {
        await rest('databaseType').del(databaseType)
        this.deleteDatabaseType(databaseType)
      }
    }
  }
</script>
