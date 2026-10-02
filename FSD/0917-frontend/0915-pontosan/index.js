const express = require('express');
const mysql = require('mysql2/promise');

const app = express();
app.use(express.json());

const pool = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'konyvtar',
    waitForConnections: true,
    connectionLimit: 10
})

const port = 3001

app.get('/', (req, res) => {
  res.send('szia')
})

app.get('/books', async (req, res) => {
    try  {
        const [rows] = await pool.query('SELECT * FROM `books`');
        res.json(rows);
        /*if (rows.length == 0){
            res.json("Üres a tábla. (esetleg nincsen adat?)");
        }
        else{
            res.json(rows);
        }*/
    } catch (error) {
        res.status(500).json({error: error.message});
    }
});

app.get('/books/:id', async (req, res) => {
    const {id} = req.params;
    try  {
        const [rows] = await pool.query('SELECT * FROM `books` WHERE id = ? ', [id]);
        res.json(rows);
        /*if (rows.length == 0){
            res.json("Üres a tábla. (esetleg nincsen adat?)");
        }
        else{
            res.json(rows);
        }*/
    } catch (error) {
        res.status(500).json({error: error.message});
    }
});

app.post('/books', async (req, res) => {
    const { title, author, published_year, is_available } = req.body;

    if(!title || !author || !published_year) return res.status(400).json({error: "Minden mező kitöltése kötelező!"})
    try  {
        const [result] = await pool.query('INSERT INTO books (title, author, published_year, is_available) VALUES (?, ?, ?, ?)', [title, author, published_year, is_available]);
        res.status(201).json({ id: result.insertId});
    } catch (error) {
        res.status(500).json({error: error.message});
    }
})
// const { title, author, published_year, is_available } = req.body;

app.delete('/books/:id', async (req, res) =>{
    const {id} = req.params;
    try{
        const [result] = await pool.query('DELETE FROM `books` WHERE id = ?', [id])

        if (result.affectedRows === 0) return res.status(404).send("Nem található ez a könyv.");

        res.json({message: "Sikeresen törölte az allábi könyvet: ", id: Number(id)});
    }
    catch (error){
        res.status(500)
    }
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})