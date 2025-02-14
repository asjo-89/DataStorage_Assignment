import React from 'react'
import Sidebar from '../components/sidebar'
import FormProject from '../components/FormProject'

function AddProject() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="add-title">
                <h1>New project</h1>
            </div>

            <Sidebar />

            <div className="content-project">            
              <FormProject />
            </div>
            </div>
        </div>
    </>
  )
}

export default AddProject
