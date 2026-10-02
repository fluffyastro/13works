import React from 'react'
import './komponens.css'

const Komponens = ({ title, question, answer }) => {
  return (
    <div className='komponens'>
      <h1>{title}</h1>
      <p>{question}</p>
      <h4>{answer}</h4>
    </div>
  )
}

export default Komponens
