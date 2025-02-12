import React from 'react'

function Sidebar() {
  return (
    <>
        <nav className="sidebar">
            <ul>
                <li className="list-object active">Overview</li>
                <li className="list-object">Employees</li>
                <li className="list-object">Customers</li>
            </ul>
        </nav>
    </>
  )
}

export default Sidebar
