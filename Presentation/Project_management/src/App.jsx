import React from 'react'

function App() {
  return (
    <>
      <div className="wrapper">
        <div className="main-container">
          <div className="main-title">
          <button className="btn">Add new project</button>

            <p>Project management</p>
          </div>

          <nav className="sidebar">
            <ul>
              <li className="list-object active">Overview</li>
              <li className="list-object">Employees</li>
              <li className="list-object">Customers</li>
            </ul>
          </nav>

          <div className="content">
            {/* <button className="btn">Add new project</button> */}
            
            <div className="ongoing">
              <div className="title">
                <p>Ongoing</p>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
            </div>

            <div className="not-started">
              <div className="title">Not started</div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
            </div>

            <div className="completed">
              <div className="title">Completed</div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
              <div className="project-mini">
                <span className="project-name">Project name</span>
                <span className="date">2025-01-01 - 2025-03-01</span>
                <span className="manager">Manager name</span>
                <span className="customer">Customer name</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  )
}

export default App
