function apiUrl (url) {
  return '/api/' + url
}

function jsonBody (option) {
  if (!option.headers) {
    option.headers = {}
  }
  option.headers['Content-Type'] = 'application/json'
  if (option.body) {
    option.body = JSON.stringify(option.body)
  }
  return option
}

async function thenJson (url, option) {
  const response = await fetch(apiUrl(url), jsonBody(option))
  const jsonData = await response.json()
  if (!response.ok) {
    throw new RestApiFailError(jsonData.message || '出现了未知的服务端错误', response.status)
  }
  return [jsonData, response]
}

export async function post (url, body) {
  return thenJson(url, {method: 'POST', body})
}

export async function get (url, body) {
  return thenJson(url, {method: 'GET', body})
}

export async function put (url, body) {
  return thenJson(url, {method: 'PUT', body})
}

export function defaultCatch (error) {
  console.debug('错误的响应内容', error.response)
  alert('提交出现了错误：' + error.message)
}

class RestApiFailError {
  constructor (message, response) {
    this.name = 'RestApiFailError'
    this.httpCode = response.status
    this.message = message
    this.response = response
  }
}
