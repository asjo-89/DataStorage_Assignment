import React from 'react'
import Sidebar from '../components/sidebar'
import AdminForm from '../components/AdminForm'

function Admin() {
  return (
    <>
        <div className="wrapper">
          <div className="main-container">
            <div className="admin-title">
                <h1>Administration</h1>
            </div>

            <Sidebar />

            <div className="content-project">   
              <AdminForm />
            </div>
          </div>
        </div>
    </>
  )
}

export default Admin
