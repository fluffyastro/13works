import React from 'react'
import './card.css'

const SablonCard = ({ name, postalCode, date}) => {
  return (
    <div className='card'>
      <h1>{name}</h1>
      <p>{postalCode}</p>
      <h4>{date}</h4>
    </div>
  )
}

export default SablonCard
