import React from 'react'
import Sidebar from '../components/sidebar'
import ProjectList from '../components/ProjectList'
import EmployeesList from '../components/EmployeesList'

function Employees() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
            <button className="btn">Add employee</button>
                <p>Employees</p>
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
