import React from 'react'
import { NavLink } from 'react-router-dom'

function Sidebar() {
  return (
    <>
      <nav className="sidebar">
        <ul>
          <li>
            <NavLink to="/" className={({isActive}) => isActive ? "list-object active" : "list-object"}>Overview</NavLink>
          </li>
          <li>
            <NavLink to="/employees" className={({isActive}) => isActive ? "list-object active" : "list-object"}>Employees</NavLink>
          </li>
          <li>
            <NavLink to="/customers" className={({isActive}) => isActive ? "list-object active" : "list-object"}>Customers</NavLink>
          </li>
          <li>
            <NavLink to="/admin" className={({isActive}) => isActive ? "list-object active" : "list-object"}>Admin</NavLink>
          </li>
        </ul>
      </nav>
    </>
  )
}

export default Sidebar
