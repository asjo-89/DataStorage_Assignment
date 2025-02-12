import React from 'react'

function ProjectList() {
  return (
    <>
        <div className="ongoing">
            <div className="title">
              <p>Ongoing</p>
            </div>
            <button className="project-mini">
              <span className="project-name">Project name</span>
              <span className="date">2025-01-01 - 2025-03-01</span>
              <span className="manager">Manager name</span>
              <span className="customer">Customer name</span>
            </button>
            <button className="project-mini">
              <span className="project-name">Project name</span>
              <span className="date">2025-01-01 - 2025-03-01</span>
              <span className="manager">Manager name</span>
              <span className="customer">Customer name</span>
            </button>
        </div>

        <div className="not-started">
            <div className="title">
              <p>Ongoing</p>
            </div>
            <button className="project-mini">
              <span className="project-name">Project name</span>
              <span className="date">2025-01-01 - 2025-03-01</span>
              <span className="manager">Manager name</span>
              <span className="customer">Customer name</span>
            </button>
            <button className="project-mini">
              <span className="project-name">Project name</span>
              <span className="date">2025-01-01 - 2025-03-01</span>
              <span className="manager">Manager name</span>
              <span className="customer">Customer name</span>
            </button>
        </div>

        <div className="completed">
            <div className="title">
              <p>Ongoing</p>
            </div>
            <button className="project-mini">
              <span className="project-name">Project name</span>
              <span className="date">2025-01-01 - 2025-03-01</span>
              <span className="manager">Manager name</span>
              <span className="customer">Customer name</span>
            </button>
              <button className="project-mini">
              <span className="project-name">Project name</span>
              <span className="date">2025-01-01 - 2025-03-01</span>
              <span className="manager">Manager name</span>
              <span className="customer">Customer name</span>
            </button>
        </div>
    </>
  )
}

export default ProjectList
