const express = require('express');
const app = express()
const port = 3002

app.get('/', (req, res) => {
  res.send('<img src="https://media1.tenor.com/m/UoABeG0xBs4AAAAd/i-guess-bro-epstein.gif" align="center"><br><h1>azt hiszem, nagy stein</h1>')
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})