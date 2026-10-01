import express from 'express'
import mysql from 'mysql2/promise'
import bcrypt from 'bcrypt'
const app = express();
app.use(express.json());
const port = 3001;

const pool = mysql.createPool({
    host: "localhost",
    user: "root",
    password: "",
    database: "remek"
})

app.get('/', (req, res) => {
    res.send("szia")
})

//REGISTER - POST
app.post('/register', async (req, res) => {
    try{
        const {name, username, password} = req.body;
        
        if(!name || !username || !password) return res.status(400).json({error: "Hiányzó adat!"});

        const [users] = await pool.query('SELECT * FROM users WHERE username = ?', [username])

        if(users.length > 0) return res.status(400).json({message: 'A felhasználónév már foglalt!'});

        const hashedPassword = await bcrypt.hash(password, 10);
        console.log(hashedPassword);

        const [result] = await pool.query('INSERT INTO users (name, username, password) values (?, ?, ?)',
            [name, username, hashedPassword]);

        res.status(201).json({ message: 'Sikeres regisztráció!', userId: result.insertId})
    } catch(error){
        console.error(error)
        res.status(500).json({error: "Internal Server Error."})
    }
})


//LOGIN - POST
app.post('/login', async (req, res) => {
    const { username, password } = req.body;

    try{
        const [rows] = await pool.query('SELECT * FROM users WHERE username = ?', [username]);

    if(rows.length === 0){
        return res.status(401).json({ error: "Hibás felhasználónév vagy jelszó!"})
    }

    const user = rows[0]

    const isPasswordValid = await bcrypt.compare(password, user.password)
    if(!isPasswordValid){
        return res.status(401).json({ error: "Hibás felhasználónév vagy jelszó!"})
    }


    res.json({message: "Sikeres bejelentkezés!"})
    } catch(error){
        console.error(error)
        res.status(500).json({error: "Internal Server Error."})
    }
})


app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})