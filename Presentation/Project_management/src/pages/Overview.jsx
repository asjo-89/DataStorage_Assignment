import React from 'react'
import Sidebar from '../components/Sidebar'
import ProjectList from '../components/ProjectList'
import { NavLink } from 'react-router-dom'

function Overview() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
              <NavLink to="/addProject" className="btn">
                  Add project
              </NavLink>
              <h1>Project management</h1>
            </div>

            <Sidebar />

            <div className="content-projects">            
                <ProjectList />
            </div>
            </div>
        </div>
    </>
  )
}

export default Overview
