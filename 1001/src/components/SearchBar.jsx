import React from 'react'

const SearchBar = ({search, setSearch}) => {
  return (
    <div>
      <input type="text" value={search} onChange={(e) => {
        console.log(e.value)
        setSearch(e.target.value)
      }}/>
    </div>
  )
}

export default SearchBar
