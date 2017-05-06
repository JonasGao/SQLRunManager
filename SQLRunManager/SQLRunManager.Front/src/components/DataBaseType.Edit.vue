<template>
  <div>
    <h4>Edit Database Type</h4>
    <hr>
    <form>
      <p><label for="title">标题</label><input id="Title" type="text" v-model="model.title"></p>
      <p><label for="server">服务器地址</label><input id="Server" type="text" v-model="model.server"></p>
      <p><label for="port">端口号</label><input id="Port" type="text" v-model="model.port"></p>
      <p><label for="uid">用户名</label><input id="Uid" type="text" v-model="model.uid"></p>
      <p><label for="pwd">密码</label><input id="Pwd" type="text" v-model="model.pwd"></p>
      <p>
        <button type="button" @click="save()">提交</button>
        <button type="button" @click="cancel()">取消</button>
      </p>
    </form>
  </div>
</template>

<script>
  import { mapState, mapActions } from 'vuex'
  import { defaultCatch } from '../services/http'
  import router from '../router'
  import { clone } from 'lodash'

  export default {
    name: 'editDatabaseType',
    created () {
      this.model = clone(this.databaseType)
    },
    data () {
      return {
        model: {}
      }
    },
    computed: {
      ...mapState({
        databaseType: state => state.moduleDatabaseType.current
      })
    },
    methods: {
      ...mapActions([
        'putDatabaseType'
      ]),
      async save () {
        try {
          await this.putDatabaseType(this.model)
          router.push('/database/type')
        } catch (e) {
          defaultCatch(e)
        }
      },
      cancel () {
        router.push('/database/type')
      }
    }
  }
</script>
