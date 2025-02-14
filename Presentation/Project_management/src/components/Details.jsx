import React from 'react'

function Details({project}) {
  return (
    <>
      <div className="card-1">
        <div className="title-box">
          <h2 className="title-1">{project.id} - {project.title}</h2>
          <button className="edit">
            <img src="../images/pencil-solid.svg" alt="A pencil." />
          </button>
          <p className="text-1">{project.startDate} - {project.endDate}</p>
        </div>
        <div className="description-box">
          <h3 className="title">Description</h3>
          <p className="text description">{project.description}</p>
        </div>
        <div className="manager">
          <h3 className="title">Manager: <p className="text manager-name">{project.employee.firstName} {project.employee.lastName}</p></h3>
        </div>
      </div>

      <div className="card-2">
        <div className="details-group-4">
          <h3 className="title">Customer</h3>
          <p className="text">{project.customer.customerName}</p>
          <h3 className="title">Phone number</h3>
          <p className="text">{project.customer.phoneNumber}</p>
          <h3 className="title">Email</h3>
          <p className="text">{project.customer.email}</p>
        </div>
      </div>

      <div className="card-3">
        <div className="details-group-5">
          <h3 className="title">Service</h3>
          <p className="text">{project.service.serviceName} {project.service.price} {project.service.unit}</p>
        </div>
        <div className="details-group-6">
          <h3 className="title">Status</h3>
          <p className="text">{project.statusInformation.statusName}</p>
        </div>
      </div>
    </>
  )
}

export default Details
