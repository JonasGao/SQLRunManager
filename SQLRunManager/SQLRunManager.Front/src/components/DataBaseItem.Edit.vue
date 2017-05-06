<template>
  <div>
    <h4>Edit Database Item</h4>
    <hr>
    <form>
      <p v-if="isCreate">
        <label for="type">类型</label>
        <select name="type" id="type" v-model="selectedType" @change="selectedTypeChanged">
          <option v-for="type in databaseTypes" :value="type">{{type.title}}</option>
        </select>
      </p>
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
  import { assign, clone } from 'lodash'
  import router from '../router'

  export default {
    name: 'editDatabaseItem',
    created () {
      this.getDatabaseTypes()
      this.model = clone(this.databaseItem)
    },
    data () {
      return {
        model: null,
        selectedType: null
      }
    },
    computed: {
      ...mapState({
        databaseTypes: state => state.moduleDatabaseType.list,
        databaseItem: state => state.moduleDatabaseItem.current
      }),
      isCreate () {
        return this.$route.params.mode !== 'edit'
      }
    },
    methods: {
      ...mapActions([
        'putDatabaseItem',
        'getDatabaseTypes'
      ]),
      async save () {
        try {
          await this.putDatabaseItem(this.model)
          router.push('/database/item')
        } catch (e) {
          defaultCatch(e)
        }
      },
      cancel () {
        router.go(-1)
      },
      selectedTypeChanged () {
        assign(this.model, this.selectedType)
      }
    }
  }
</script>
