import express from 'express';
import db from '../config/db.js';

const router = express.Router();

// GET /api/tasks/stats - Statisztikák lekérése (MINDIG a /:id előtt legyen)

router.get('/stats', async (req, res) => {
    try{
        const [totalRows] = await db.query('SELECT COUNT(*) AS total FROM tasks')
        const [statusRows] = await db.query('SELECT status, COUNT(*) AS count FROM tasks GROUP BY status')

        const status = {
            total: totalRows[0].total,
            TODO: 0,
            IN_PROGRESS: 0,
            DONE: 0
        };

        statusRows.forEach(sor => {
            stats[sor.status] = sor.count;
        });

        res.json(stats)
    } catch (error) {
        res.status(500).json({error: 'Internal Server Error'})
    }
})

// GET /api/tasks - Feladatok listázása (összekötéssel)

router.get('/', async (req, res) => {
    try{
        let sql = `SELECT t.id, t.description, t.status, t.priority, t.created_at, c.id AS category_id, c.name AS category_name, c.color as category_color
        FROM 
        tasks t LEFT JOIN categories c ON t.category_id = c.id WHERE 1=1`
        const [results] = await db.query(sql);


        res.json(results)
    } catch (error) {
        res.status(500).json({error: `Internal Server Error ${error}`})
    }
});

// POST /api/tasks - Új feladat létrehozésa

router.post('/', async (req, res) => {
    try{
        const {title, description, status, priority, category_id} = req.body;

        if (!title) {
            return res.status(400).json({error: 'A cím megadása kötelező!'})
        }

        const [results] = await db.query(`INSERT INTO tasks (title, description, status, priority, category_id)
            VALUES (?,?,?,?,?)`, [
                title,
                description || "",
                status || "TODO",
                priority || "MEDIUM",
                category_id || null
            ]);

        const [newTask] = await db.query(`SELECT t.*, c.name AS category_name, c.color AS category_color FROM tasks t LEFT JOIN categories c ON t.category_id = c.id WHERE t.id=?`, [results.insertId]);

        res.status(201).json(newTask);


        res.json(results)
    } catch (error) {
        res.status(500).json({error: `Internal Server Error ${error}`})
    }
})

// PUT /api/tasks/:id 

// DELETE /api/tasks/:id

router.delete('/:id', async (req, res) => {
    try{
        const { id } = req.params;
        const [result] = await db.query('DELETE FROM tasks WHERE id=?', [id])

        if (result.affectedRows === 0){
            return res.status(404).json({error: "A feladat nem található!"})
        }
    } catch (error) {
        res.status(500).json({error: `Internal Server Error ${error}`})
    }
})

export default router;