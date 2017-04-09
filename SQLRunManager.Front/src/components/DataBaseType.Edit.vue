<template>
  <div>
    <h4>Edit Database Type</h4>
    <hr>
    <form>
      <p><label for="title">标题</label><input id="Title" type="text" v-model="databaseType.title"></p>
      <p><label for="server">服务器地址</label><input id="Server" type="text" v-model="databaseType.server"></p>
      <p><label for="port">端口号</label><input id="Port" type="text" v-model="databaseType.port"></p>
      <p><label for="uid">用户名</label><input id="Uid" type="text" v-model="databaseType.uid"></p>
      <p><label for="pwd">密码</label><input id="Pwd" type="text" v-model="databaseType.pwd"></p>
      <p><button type="button" @click="save()">提交</button></p>
    </form>
  </div>
</template>

<script>
  import {mapGetters, mapMutations} from 'vuex'
  import { post, defaultCatch } from '@/utils/rest'
  import router from '@/router'

  export default {
    name: 'editDatabaseType',
    computed: {
      ...mapGetters([
        'databaseType'
      ])
    },
    methods: {
      ...mapMutations([
        'pushDatabaseType'
      ]),
      async save () {
        try {
          await post('databaseType', this.databaseType)
          this.pushDatabaseType(this.databaseType)
          router.push('/database/type')
        } catch (e) {
          defaultCatch(e)
        }
      }
    }
  }
</script>
