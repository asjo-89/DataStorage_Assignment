import React from 'react'

function ProjectList() {
  return (
    <>
        <div className="ongoing">
            <div className="title">
              <h2>Ongoing</h2>
            </div>
            <button className="project-mini">
              <h3 className="project-name">Project name</h3>
              <p className="date">2025-01-01 - 2025-03-01</p>
              <p className="manager">Manager name</p>
              <p className="customer">Customer name</p>
            </button>
            <button className="project-mini">
              <h3 className="project-name">Project name</h3>
              <p className="date">2025-01-01 - 2025-03-01</p>
              <p className="manager">Manager name</p>
              <p className="customer">Customer name</p>
            </button>
        </div>

        <div className="not-started">
            <div className="title">
              <h2>Not started</h2>
            </div>
            <button className="project-mini">
              <h3 className="project-name">Project name</h3>
              <p className="date">2025-01-01 - 2025-03-01</p>
              <p className="manager">Manager name</p>
              <p className="customer">Customer name</p>
            </button>
            <button className="project-mini">
              <h3 className="project-name">Project name</h3>
              <p className="date">2025-01-01 - 2025-03-01</p>
              <p className="manager">Manager name</p>
              <p className="customer">Customer name</p>
            </button>
        </div>

        <div className="completed">
            <div className="title">
              <h2>Completed</h2>
            </div>
            <button className="project-mini">
              <h3 className="project-name">Project name</h3>
              <p className="date">2025-01-01 - 2025-03-01</p>
              <p className="manager">Manager name</p>
              <p className="customer">Customer name</p>
            </button>
              <button className="project-mini">
              <h3 className="project-name">Project name</h3>
              <p className="date">2025-01-01 - 2025-03-01</p>
              <p className="manager">Manager name</p>
              <p className="customer">Customer name</p>
            </button>
        </div>
    </>
  )
}

export default ProjectList
