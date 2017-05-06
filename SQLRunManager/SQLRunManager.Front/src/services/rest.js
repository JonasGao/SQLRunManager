import { defaultCatch, del, get, post, put } from './http'

export function rest (url, catcher) {
  return new MySimpleResources(url, catcher)
}

export default function (url) {
  return rest(url, defaultCatch)
}

class MySimpleResources {
  constructor (url, catcher) {
    this.url = url
    this.catcher = catcher
  }

  catchThis (e) {
    if (this.catcher) {
      this.catcher(e)
      return
    }
    throw e
  }

  async post (body) {
    try {
      return await post(this.url, body)
    } catch (e) {
      this.catchThis(e)
    }
  }

  async get (body) {
    try {
      return await get(this.url, body)
    } catch (e) {
      this.catchThis(e)
    }
  }

  async put (body) {
    try {
      return await put(this.url, body)
    } catch (e) {
      this.catchThis(e)
    }
  }

  async del (body) {
    try {
      return await del(this.url, body)
    } catch (e) {
      this.catchThis(e)
    }
  }
}
