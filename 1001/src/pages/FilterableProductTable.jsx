import React, { useState } from 'react'
import SearchBar from '../components/SearchBar'
import ProductTable from '../components/ProductTable'

const FilterableProductTable = ({products}) => {
    const [search, setSearch] = useState("");


  return (
    <div>
        <SearchBar saerch={search} setSearch={setSearch}/>
        <ProductTable products={products} search={search}/>
    </div>
  )
}

export default FilterableProductTable