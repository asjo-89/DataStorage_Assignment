import React from 'react'
import Sidebar from '../components/Sidebar'
import Details from '../components/Details'
import { NavLink, useLocation } from 'react-router-dom'

function ProjectDetails() {
  const location = useLocation();
  const { project } = location.state || {};

  console.log("import22", project)

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
                <Details project={project} /> 
            </div>
            </div>
        </div>
    </>
  )
}

export default ProjectDetails
