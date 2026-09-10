const express = require('express');
const mysql = require('mysql2/promise');

const app = express();
app.use(express.json())
const port = 3002;

const pool = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'nodetest',
    waitForConnections: true,
    connectionLimit: 10
})

//GET - felhasználókat (USERS TÁBLA)


app.get('/users', async (req, res) => {
    try  {
        const [rows] = await pool.query('SELECT * FROM users');
        if (rows.length == 0){
            res.json("no users found");
        }
        else{
            res.json(rows);
        }
    } catch (error) {
        res.status(500).json({error: error.message});;
    }
})

// POST - Hozzáadás

app.post('/users', async (req, res) => {
    const { name, email } = req.body;
    try  {
        const [result] = await pool.query('INSERT INTO users (name, email) VALUES (?, ?)', [name, email]);
        res.status(201).json(result);
    } catch (error) {
        res.status(500).json({error: error.message});;
    }
})

// PUT/UPDATE - Frissítés 

app.put('/users/:id', async (req, res) => {
    const { name, email } = req.body;
    const { id } = req.params;
    try  {
        const [result] = await pool.query('UPDATE users SET name=?, email=? WHERE id=?', [name, email, id]);
        
        if(result.affectedRows === 0) return res.status(404).send('Nem található a megadott elem.');

        res.json({ id: Number(id), name, email});

        res.status(201).json(result);
    } catch (error) {
        res.status(500).json({error: error.message});
    }
})

app.get('/', (req, res) => {
  res.send('<img src="https://media1.tenor.com/m/UoABeG0xBs4AAAAd/i-guess-bro-epstein.gif"><br><h1>azt hiszem, nagy stein</h1>')
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})