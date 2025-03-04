import React from 'react'
import { NavLink } from 'react-router-dom'

function ProjectCards({ classname, title, projects}) {
    console.log("import", projects)
  return (
    <>
        <div className={classname}>
            <div className="title">
                <h2>{title}</h2>
            </div>
            <div className="project-container">

                {projects.length > 0 
                    ? (projects.map((project) => (
                        <NavLink to="/projectDetails" className="project-mini" key={project.id}
                            state={{
                                project,
                                customerId: project.customerId,
                                employeeId: project.employeeId,
                                statusInformationId: project.statusInformationId,
                                serviceId: project.serviceId
                            }} >
                            <h2 className="project-name">{project.id} - {project.projectTitle}</h2>
                            <h3 className="date">{project.startDate?.split("T")[0] ?? "No date"} - {project.endDate?.split("T")[0] ?? "No date"}</h3>
                            <p className="manager">{project.employee ? `${project.employee.firstName} ${project.employee.lastName}` : "Unknown"}</p>
                            <p className="customer">{project.customer.customerName ?? "Unknown"}</p>
                        </NavLink>
                    )))
                : (<p>No projects found.</p>)}

            </div>
        </div>
    </>
  )
}

export default ProjectCards


