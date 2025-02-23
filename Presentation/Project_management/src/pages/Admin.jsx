import React from 'react'
import Sidebar from '../components/sidebar'
import AdminForm from '../components/AdminForm'
import { NavLink } from 'react-router-dom'

function Admin() {
  return (
    <>
        <div className="wrapper">
          <div className="main-container">
          <div className="main-title">
              <NavLink to="/admin" className="btn">
                  Add project
              </NavLink>
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
