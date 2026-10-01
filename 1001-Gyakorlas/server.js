import express from 'express'
import mysql from 'mysql2/promise'

const app = express();
app.use(express.json());
const port = 3001;

const pool = mysql.createPool({
    host: "localhost",
    user: "root",
    password: "",
    database: "spookygyakorlas"
})

app.get('/', (req, res) => {
    res.send("szia")
})

// összes GET-elése (NOTES)

app.get('/notes', async (req, res) => {
    try  {
        const [rows] = await pool.query('SELECT * FROM `notes`');
        if (rows.length == 0){
            res.json("Üres a tábla. (esetleg nincsen adat?)");
        }
        else{
            res.json(rows);
        }
    } catch (error) {
        res.status(500).json({error: error.message});
    }
});



// összes GET-elése (EXPENSES)

app.get('/expenses', async (req, res) => {
    try  {
        const [rows] = await pool.query('SELECT * FROM `expenses`');
        if (rows.length == 0){
            res.json("Üres a tábla. (esetleg nincsen adat?)");
        }
        else{
            res.json(rows);
        }
    } catch (error) {
        res.status(500).json({error: error.message});
    }
});



// ID alapján GET-elés (NOTES)

app.get('/notes/:id', async (req, res) => {
    const {id} = req.params;
    try  {
        const [rows] = await pool.query('SELECT * FROM `notes` WHERE id = ? ', [id]);
        if (rows.length == 0){
            res.json("Üres a tábla. (esetleg nincsen adat?)");
        }
        else{
            res.json(rows);
        }
    } catch (error) {
        res.status(500).json({error: error.message});
    }
});



// ID alapján GET-elés (EXPENSES)

app.get('/expenses/:id', async (req, res) => {
    const {id} = req.params;
    try  {
        const [rows] = await pool.query('SELECT * FROM `expenses` WHERE id = ? ', [id]);
        if (rows.length == 0){
            res.json("Üres a tábla. (esetleg nincsen adat?)");
        }
        else{
            res.json(rows);
        }
    } catch (error) {
        res.status(500).json({error: error.message});
    }
});



// POST (NOTES)

app.post('/notes', async (req, res) => {
    const { title, content, color, is_pinned } = req.body;
    try  {
        const [result] = await pool.query('INSERT INTO notes (title, content, color, is_pinned) VALUES (?, ?, ?, ?)', [title, content, color, is_pinned]);
        res.status(201).json({ id: result.insertId});
    } catch (error) {
        res.status(500).json({error: error.message});
    }
})



// POST (EXPENSES)

app.post('/expenses', async (req, res) => {
    const { title, amount, category, payment } = req.body;
    try  {
        const [result] = await pool.query('INSERT INTO expenses (title, amount, category, payment) VALUES (?, ?, ?, ?)', [title, amount, category, payment]);
        res.status(201).json({ id: result.insertId});
    } catch (error) {
        res.status(500).json({error: error.message});
    }
})



// DELETE (NOTES)

app.delete('/notes/:id', async (req, res) =>{
    const {id} = req.params;
    try{
        const [result] = await pool.query('DELETE FROM `notes` WHERE id = ?', [id])

        if (result.affectedRows === 0) return res.status(404).send("A jegyzet nem található.");

        res.json({message: "Törölte ezt a jegyzetet: ", id: Number(id)});
    }
    catch (error){
        res.status(500)
    }
})



// DELETE (EXPENSES)

app.delete('/expenses/:id', async (req, res) =>{
    const {id} = req.params;
    try{
        const [result] = await pool.query('DELETE FROM `expenses` WHERE id = ?', [id])

        if (result.affectedRows === 0) return res.status(404).send("Nem található.");

        res.json({message: "Sikeresen törölte ezt: ", id: Number(id)});
    }
    catch (error){
        res.status(500)
    }
})





app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})