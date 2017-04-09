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
  return [jsonData, response]
}

export async function post (url, body) {
  return thenJson(url, {method: 'POST', body})
}

export async function get (url, body) {
  return thenJson(url, {method: 'GET', body})
}
