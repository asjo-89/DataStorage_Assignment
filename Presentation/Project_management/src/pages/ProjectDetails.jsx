import React from 'react'
import Sidebar from '../components/sidebar'
import Details from '../components/Details'
import { NavLink } from 'react-router-dom'

function ProjectDetails() {
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
                <Details /> 
            </div>
            </div>
        </div>
    </>
  )
}

export default ProjectDetails
