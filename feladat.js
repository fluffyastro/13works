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

//GET - autókat lekérdez (AUTO TÁBLA)

app.get('/auto', async (req, res) => {
    try  {
        const [rows] = await pool.query('SELECT * FROM auto');
        if (rows.length == 0){
            res.json("Üres a tábla. (esetleg üres?)");
        }
        else{
            res.json(rows);
        }
    } catch (error) {
        res.status(500).json({error: error.message});;
    }
})

// POST - Hozzáadás

app.post('/auto', async (req, res) => {
    const { marka, model, ccm, evjarat, szin } = req.body;
    try  {
        const [result] = await pool.query('INSERT INTO auto (marka, model, ccm, evjarat, szin) VALUES (?, ?, ?, ?, ?)', [marka, model, ccm, evjarat, szin]);
        res.status(201).json(result);
    } catch (error) {
        res.status(500).json({error: error.message});;
    }
})

// PUT/UPDATE - Frissítés 

app.put('/auto/:id', async (req, res) => {
    const { marka, model, ccm, evjarat, szin } = req.body;
    const { id } = req.params;
    try  {
        const [result] = await pool.query('UPDATE auto SET marka=?, model=?, ccm=?, evjarat=?, szin=? WHERE id=?', [marka, model, ccm, evjarat, szin, id]);
        
        if(result.affectedRows === 0) return res.status(404).send('Nem található a megadott elem.');

        res.json({ id: Number(id), marka, model, ccm, evjarat, szin});

        res.status(201).json(result);
    } catch (error) {
        res.status(500).json({error: error.message});
    }
})

app.delete()

app.get('/', (req, res) => {
  res.send('<img src="https://media1.tenor.com/m/UoABeG0xBs4AAAAd/i-guess-bro-epstein.gif"><br><h1>azt hiszem, nagy stein</h1>')
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})