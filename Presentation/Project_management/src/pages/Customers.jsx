import React from 'react'
import CustomersList from '../components/CustomersList'
import Sidebar from '../components/sidebar'

function Customers() {
  return (
    <>
        <div className="wrapper">
            <div className="main-container">
            <div className="main-title">
            <button className="btn">Add customer</button>
                <p>Customers</p>
            </div>

            <Sidebar />

            <div className="content-customers">            
                <CustomersList />
            </div>
            </div>
        </div>
    </>
  )
}

export default Customers
