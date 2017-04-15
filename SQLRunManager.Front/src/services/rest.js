import { defaultCatch, del, get, post, put } from 'http'

export function resources (url) {
  return new MySimpleResources(url)
}

class MySimpleResources {
  constructor (url) {
    this.url = url
  }

  async post (body) {
    try {
      return await post(this.url, body)
    } catch (e) {
      defaultCatch(e)
    }
  }

  async get (body) {
    try {
      return await get(this.url, body)
    } catch (e) {
      defaultCatch(e)
    }
  }

  async put (body) {
    try {
      return await put(this.url, body)
    } catch (e) {
      defaultCatch(e)
    }
  }

  async del (body) {
    try {
      return await del(this.url, body)
    } catch (e) {
      defaultCatch(e)
    }
  }
}
