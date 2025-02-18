import React, { useEffect, useState } from 'react'
import { NavLink } from 'react-router-dom'

function Details({project, customer, customers, employee, employees, services, statuses}) {

  const [isEditing, setIsEditing] = useState(true);
  const [editedProject, setEditedProject] = useState();
  const [editedCustomer, setEditedCustomer] = useState();
  const [editedService, setEditedService] = useState();
  const [editedStatus, setEditedStatus] = useState();
  const [newServiceId, setNewServiceId] = useState();
  const [newEmployee, setNewEmployee] = useState();

// console.log(`Employees: ${employees}`);
if (!employees || Object.keys(employees).length === 0) {
  return <div>Loading employees...</div>}

  console.log(services);

  const handleClick = () => {
      setIsEditing(prev => !prev);
  }

  const handleNewService = (e) => {
    const newService = e.target.value;
    setNewServiceId(newService);
    handleChange(e, "service", "serviceId")
  }

  const handleEmployee = (e) => {
    const employee = e.target.value;
    setNewEmployee(employee);
    handleChange(e, "employee", "employeeId")
  }

  const handleChange = (e, type, field) => {
    const {value} = e.target;
    
    if(type === "employee") {
      setEditedProject(prev => ({...prev, employee: {...prev.employee, employeeId: value}}));
    }
    else if (type === "project") {
      setEditedProject(prev => ({...prev, [field]: value}));
    }
    else if (type === "customer") {
      setEditedCustomer(prev => ({...prev, customerId: value}));
    }
    else if (type === "service") {
      setEditedService(prev => ({...prev, serviceId: value}));
    }
    else {
      setEditedStatus(prev => ({...prev, statusInformationId: value}));
    }
  }
    

  const employeesList = employees
    ? Object.entries(employees).map(([id, name]) => ({ id, name }))
    : [];

  const customersList = customers
    ? Object.entries(customers).map(([id, customer]) => ({id, name: customer.customerName}))
    : [];

  const serviceList = services
    ? Object.entries(services).map(([id, service]) => ({id, name: service.serviceName}))
    : [];

  const statusList = statuses
    ? Object.entries(statuses).map(([id, name]) => ({id, name}))
    : [];
    


  return (
    <>
      <div className="card-1">
        <div className="title-box">
          <h2 className="title-1">{project.id || ""} - {isEditing ? (
            <input className="input" type="text" value={project.title || ""} onChange={(e) => handleChange(e, "project", "title")} />
            ) : (project.title || "")}</h2>  
          <p className="text-1">
          {isEditing ? (
            <>
              <input className="input" type="date" value={project.startDate || ""} onChange = {(e) => handleChange(e, "project", "startDate")} />
                - 
              <input className="input" type="date" value={project.endDate || ""} onChange = {(e) => handleChange(e, "project", "endDate")} />
            </>)
          : (`${project.startDate || ""} - ${project.endDate || ""}`)}</p>
        </div>

        <div className="description-box">
          <h3 className="title">Description</h3>
            {isEditing ? (
              <input className="input" type="text" 
                value={project.description || ""} onChange = {(e) => handleChange(e, "project", "description")} />
              ) 
              : <p className="text description">{project.description || ""}</p>}
        </div>

        <div className="manager">
          <h3 className="title">Manager: 
            {isEditing ? (
              <select className="input" type="text" 
                value={project.employee ? project.employee.id : ""} 
                onChange = {handleEmployee}>
                {employeesList.map((employee) => (
                <option key={employee.id} value={employee.id}>
                  {employee.name}
                </option>
                ))}
              </select>
              ) 
              : (<p className="text manager-name">{employee.firstName || ""} {employee.lastName || ""}</p>)}
          </h3>
        </div>
        <div className="buttons">
          <button className="btn save" onClick={handleClick}>
            {isEditing ? "Save" : "Edit"}
          </button>
          <NavLink to="/" className="btn cancel">
            {isEditing ? "Cancel" : "Go back"}
          </NavLink>
        </div>
      </div>

      <div className="card-2">
        <div className="details-group-4">
          <h3 className="title">Customer</h3>
          {isEditing ? (
            <select className="input" type="text"
              value={project.customer ? project.customer.id : ""} 
              onChange={(e) => handleChange(e, "customer", "customerId")}>
              {customersList.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.name}
                </option>
              ))}
            </select>)
          : (<p className="text">{customer.customerName || ""}</p>)}

          <h3 className="title">Phone number</h3>
          {isEditing ? (
            <input className="input" type="text"
              value={customer.phoneNumber || ""} onChange={(e) => handleChange(e, "project", "phoneNumber")} />
            )
            : (<p className="text">{customer.phoneNumber || ""}</p>)}

          <h3 className="title">Email</h3>
          {isEditing ? (
            <input className="input" type="text"
              value={customer.email || ""} onChange={(e) => handleChange(e, "project", "email")} />
            )
            : (<p className="text">{customer.email || ""}</p>)}
        </div>
      </div>

      <div className="card-3">
        <div className="details-group-5">
          <h3 className="title">Service</h3>
          {isEditing ? (
            <select className="input" type="text"
              value={project.service ? project.service.id : ""} 
              onChange={handleNewService}>
                {serviceList.map((service) => (
                  <option key={service.id} value={service.id}>
                    {service.name}
                  </option>
                ))}
              </select>)
            : (<p className="text">{project.service.serviceName || ""} {project.service.price || ""} {project.service.unit || ""}</p>)}
          
        </div>
        <div className="details-group-6">
          <h3 className="title">Status</h3>
          {isEditing ? (
            <select className="input" type="text"
              value={project.statusInformation ? project.statusInformation.id : ""} 
              onChange={(e) => handleChange(e, "project", "statusId")}>
                {statusList.map((statusItem) => (
                  <option key={statusItem.id} value={statusItem.id}>
                    {statusItem.name}
                  </option>
                ))}
            </select>
            )
            : (<p className="text">{project.statusInformation.statusName || ""}</p>)}
          
          
        </div>
      </div>
    </>
  )
}

export default Details
