import express from 'express'
import mysql from 'mysql2/promise'
import dotenv from 'dotenv';
import db from './config/db.js';

dotenv.config();

const app = express();
const PORT = process.env.PORT || 3001;

const pool = mysql.createPool({
    host: process.env.DB_HOST,
    user: process.env.DB_USER,
    password: process.env.DB_PASSWORD,
    database: process.env.DB_NAME,
})

//middleware
app.use(express.json());


app.get('/api/health', async (req, res) => {
    try{
        const [rows] = await db.query('SELECT 1+1 AS result');
        res.json({status: 'OK', dbConnection: true, testResult: rows[0].result});
    } catch(error) {
        console.error(error);
        res.status(500).json({status: 'ERROR', message: 'Internal Server Error'})
    }
});


app.get('/', (req, res) => {
    res.send("szia")
})


app.get('/api/projektek/:projekt_id/feladatok', async (req, res) => {
    const {projekt_id} = req.params;
    try  {
        const [rows] = await pool.query('SELECT * FROM `projektek` JOIN feladatok WHERE projekt_id=? ', [projekt_id]);
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

app.get('/api/feladatok/:id', async (req, res) => {
    const {id} = req.params;
    try  {
        const [rows] = await pool.query('SELECT * FROM `feladatok` WHERE id = ? ', [id]);
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

app.put('/api/feladatok/:id', async (req, res) => {
    const { projekt_id, feladat_neve, leiras, statusz, prioritas, hatarido, becsult_ido, felelos_neve } = req.body;
    const { id } = req.params;
    try  {
        const [result] = await pool.query('UPDATE feladatok SET projekt_id=?, feladat_neve=?, leiras=?, statusz=?, prioritas=?, hatarido=?, becsult_ido=?, felelos_neve=? WHERE id=?', [projekt_id, feladat_neve, leiras, statusz, prioritas, hatarido, becsult_ido, felelos_neve, id]);
        if(result.affectedRows === 0) return res.status(404).send('Nem található a megadott elem.');

        res.json({ id: Number(id), projekt_id, feladat_neve, leiras, statusz, prioritas, hatarido, becsult_ido, felelos_neve});

        res.status(201).json(result);
    } catch (error) {
        res.status(500).json({error: error.message});
    }
})

app.delete('/api/feladatok/:id', async (req, res) =>{
    const {id} = req.params;
    try{
        const [result] = await pool.query('DELETE FROM `feladatok` WHERE id = ?', [id])

        if (result.affectedRows === 0) return res.status(404).send("A feladat nem található.");

        res.json({message: "Törölte ezt a feladatot: ", id: Number(id)});
    }
    catch (error){
        res.status(500)
    }
})

app.listen(PORT, () => {
    console.log(`Szerver elndítva ezen a porton: ${PORT}`)
})





/*
Projekthez kötött feladat-kezelés

• GET /api/projects/{projectId}/tasks
    • Leírás: Egy adott projekthez tartozó összes feladat kilistázása.
• GET /api/tasks/{id}
    • Leírás: Egy konkrét feladat részleteinek lekérése. ✅
• PUT /api/tasks/{id}
    • Leírás: Egy konkrét feladat teljes frissítése. ✅
• DELETE /api/tasks/{id}
    • Leírás: Egy konkrét feladat törlése. ✅
*/