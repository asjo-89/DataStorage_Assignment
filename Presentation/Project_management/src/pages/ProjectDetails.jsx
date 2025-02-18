import React from 'react'
import Sidebar from '../components/sidebar'
import Details from '../components/Details'
import { NavLink, useLocation } from 'react-router-dom'

function ProjectDetails() {
  const location = useLocation();
  const { project, customer, customers, employee, employees, services, statuses } = location.state || {};
// console.log(location)

if (!employees || Object.keys(employees).length === 0) {
  return <div>Loading employees...</div>;
}
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
              <NavLink to="/addProject" className="btn">
                  Add project
              </NavLink>
              <h1>Project details</h1>
            </div>

            <Sidebar />

            <div className="content-details">
                <Details project={project} customer={customer} employee={employee} employees={employees} customers={customers} services={services} statuses={statuses} /> 
            </div>
            </div>
        </div>
    </>
  )
}

export default ProjectDetails
