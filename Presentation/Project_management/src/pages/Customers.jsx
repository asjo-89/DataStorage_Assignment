import React from 'react'
import CustomersList from '../components/CustomersList'
import Sidebar from '../components/Sidebar'
import { NavLink } from 'react-router-dom'

function Customers() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
              <NavLink to="/addProject" className="btn">
                  Add project
              </NavLink>
              <h1>Customers</h1>
            </div>

            <Sidebar />

            <div className="content-customers">            
                <CustomersList />
            </div>
            </div>
        </div>
    </>
  )
}

export default Customers
