import { useEffect, useState } from 'react'
import heroImg from './assets/hero.png'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import './App.css'
import Header from './components/Header'


const API = "http://localhost:5000/api";
function App() {
  const [stats, setStats] = useState([])

  const fetchStats = async () => {
    try{
      const res = await fetch(API+`/tasks/stats`);
      const data = await res.json();
      setStats(data);
      console.log(data);

    } catch (error){
      console.log(error);
    }
  }

  useEffect(() =>{
    fetchStats();
  }, [])

  return (
    <>
      <div>
        <Header stats={stats}/>
      </div>
    </>
  )
}

export default App
