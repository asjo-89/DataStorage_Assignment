import React from 'react'
import Sidebar from '../components/sidebar'
import EmployeesList from '../components/EmployeesList'
import { NavLink } from 'react-router-dom'

function Employees() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
              <NavLink to="/addProject" className="btn">
                  Add project
              </NavLink>
              <h1>Employees</h1>
            </div>

            <Sidebar />

            <div className="content-employees">            
                <EmployeesList />
            </div>
            </div>
        </div>
    </>
  )
}

export default Employees
