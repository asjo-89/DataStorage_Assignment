import React from 'react'
import Sidebar from '../components/sidebar'
import Details from '../components/Details'

function ProjectDetails() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
            <button className="btn">Project details</button>
                <p>New project</p>
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
