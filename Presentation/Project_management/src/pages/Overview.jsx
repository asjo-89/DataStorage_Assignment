import React from 'react'
import Sidebar from '../components/sidebar'
import ProjectList from '../components/ProjectList'

function Overview() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
            <button className="btn">Add project</button>
                <p>Project management</p>
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
