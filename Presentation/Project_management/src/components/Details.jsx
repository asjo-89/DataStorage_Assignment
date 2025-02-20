import React, { useEffect, useState } from 'react'
import { NavLink } from 'react-router-dom'

function Details({project}) {

  console.log("details", project)
  const [isEditing, setIsEditing] = useState(false);
  const [editedProject, setEditedProject] = useState({
        id: "",
        projectTitle: "",
        description: "",
        startDate: "",
        endDate: "",
        statusInformationId: "",
        statusInformation: "",
        employeeId: "",
        employee: "",
        customerId: "",
        customer: "",
        customerPhone: "",
        customerEmail: "",
        serviceId: "",
        service: ""
  });
  const [editedEmployee, setEditedEmployee] = useState([]);
  const [editedCustomer, setEditedCustomer] = useState([]);
  const [editedService, setEditedService] = useState([]);
  const [editedStatus, setEditedStatus] = useState([]);

  console.log("kejrh")


  useEffect(() => {
    console.log("tjosan")
    if (project)
    {
      setEditedProject({
        id: project.id || "",
        projectTitle: project.projectTitle || "",
        description: project.description || "",
        startDate: project.startDate?.split("T")[0] ?? "",
        endDate: project.endDate?.split("T")[0] ?? "",
        statusInformationId: project.statusInformationId || "",
        statusInformation: project.statusInformation.statusName || "",
        employeeId: project.employeeId || "",
        employee: `${project.employee.firstName} ${project.employee.lastName}` || "",
        customerId: project.customerId || "",
        customer: project.customer.customerName || "",
        customerPhone: project.customer.phoneNumber,
        customerEmail: project.customer.email || "",
        serviceId: project.serviceId || "",
        service: `${project.service.serviceName} ${project.service.price} ${project.service.unit}` || ""
    })};

    console.log("hello");

}, [project]);

useEffect(() => {
  fetchCustomers();
  fetchEmployees();
  fetchServices();
  fetchStatuses();
}, []);

  const fetchEmployees = async () => {
    const response = await fetch("https://localhost:7273/api/employee");
    const data = await response.json();

    console.log("Employees details", data);
    setEditedEmployee(data);
  }                                     

  const fetchCustomers = async () => {
    const response = await fetch("https://localhost:7273/api/customer");
    const data = await response.json();

    console.log("Customer details", data);
    setEditedCustomer(data);
  } 

  const fetchServices = async () => {
    const response = await fetch("https://localhost:7273/api/services");
    const data = await response.json();

    console.log("Service details", data);
    setEditedService(data);
  } 
  
  const fetchStatuses = async () => {
    const response = await fetch("https://localhost:7273/api/statusInformation");
    const data = await response.json();

    console.log("Status details", data);
    setEditedStatus(data);
  } 
  const handleClick = async (e) => {
      if (isEditing) 
      {
        await handleSubmit(e);
      }      
      setIsEditing(!isEditing);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();
    const fieldNotEmpty = Object.fromEntries(
      Object.entries(editedProject)
        .filter(([key]) => !["customer", "customerPhone", "customerEmail", "employee", "statusInformation", "service"].includes(key))
        .map(([key, value]) => [key, value === "" ? null : value])
    );
    console.log("Sending data to API:", JSON.stringify(fieldNotEmpty, null, 2));

    try {
      const response = await fetch(`https://localhost:7273/api/project/`, {
        method: "PUT",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(fieldNotEmpty)
      });
      
      if (!response.ok) {
        console.log("Failed to update changes", JSON.stringify(fieldNotEmpty));
      }

      const data = await response.json();
      console.log("Update successful.", data);
    }
    catch (error) {
      console.log("PUT failed: ", {error});
    }
  }

  const handleChange = (e) => {
    const value = e.target.value;
    const name = e.target.name;    

    if (name === "customerId") {
      const customer = editedCustomer.find(c => c.id == parseInt(value));

      setEditedProject((prev) => ({...prev,
        customerId: value,
        customer: customer.customerName || "",
        customerPhone: customer.phoneNumber || "",
        customerEmail: customer.email || ""
      }))
    }

    setEditedProject((prev) => ({...prev, [name]: value}));
    console.log("edited", {editedProject});
  }    


  return (
    <>
    <form className="container">
      <div className="card-1">
        <div className="title-box">
          <h2 className="title-1">{editedProject.id || ""} - {isEditing ? (
            <input className="input" type="text" name="projectTitle" value={editedProject.projectTitle || ""} onChange={handleChange} />
            ) : (editedProject.projectTitle || "")}</h2>  
          <p className="text-1">
          {isEditing ? (
            <>
              <input className="input" type="date" name="startDate" value={editedProject.startDate || ""} onChange = {handleChange} />
                - 
              <input className="input" type="date"name="endDate" value={editedProject.endDate || ""} onChange = {handleChange} />
            </>)
          : (`${editedProject.startDate || ""} - ${editedProject.endDate || ""}`)}</p>
        </div>

        <div className="description-box">
          <h3 className="title">Description</h3>
            {isEditing ? (
              <textarea className="input description" type="text"  name="description"
                value={editedProject.description || ""} onChange = {handleChange} />
              ) 
              : <p className="text description">{editedProject.description || ""}</p>}
        </div>

        <div className="manager">
          <h3 className="title">Manager: 
            {isEditing ? (
              <select className="input manager-opt" type="text"  name="employeeId"
                value={editedProject.employeeId} 
                onChange = {handleChange}>
                {editedEmployee.map((employee) => (
                <option key={employee.id} value={employee.id}>
                  {employee.firstName} {employee.lastName}
                </option>
                ))}
              </select>
              ) 
              : (<p className="text manager-name">{editedProject.employee || ""}</p>)}
          </h3>
        </div>
        <div className="buttons">
          <button className="btn save" type="button" onClick={handleClick}>
            {isEditing ? "Save" : "Edit"}
          </button>
          <NavLink to="/" className="btn cancel">
            {isEditing ? "Cancel" : "Go back"}
          </NavLink>
        </div>
      </div>

      <div className="card-2">
          <h3 className="title">Customer</h3>
          {isEditing ? (
            <select className="input customer-opt" type="text" name="customerId"
              value={editedProject.customerId} 
              onChange={handleChange}>
              {editedCustomer.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.customerName}
                </option>
              ))}
            </select>)
          : (<p className="text">{editedProject.customer || ""}</p>)}

          <h3 className="title">Phone number</h3>
          <p className="text">{editedProject.customerPhone || ""}</p>

          <h3 className="title">Email</h3>
          <p className="text">{editedProject.customerEmail || ""}</p>
       
      </div>

      <div className="card-3">
        <h3 className="title">Service</h3>
        {isEditing 
          ? (
            <select className="input service-opt" type="text" name="serviceId"
            value={editedProject.serviceId ? editedProject.service : ""} 
            onChange={handleChange}>
              {editedService.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName} {service.price} {service.unit}
                </option>
              ))}
            </select>)
          : (<p className="text">{editedProject.service}</p>)}

          {/* Lägg till totalsumma */}
          
        <h3 className="title">Status</h3>
        {isEditing 
          ? (
          <select className="input status-opt" type="text" name="statusInformationId"
            value={editedProject.statusInformationId ? editedProject.statusInformation : ""} 
            onChange={handleChange}>
              {editedStatus.map((statusItem) => (
                <option key={statusItem.id} value={statusItem.id}>
                  {statusItem.statusName}
                </option>
              ))}
          </select>)
          : (<p className="text">{editedProject.statusInformation || ""}</p>)}
        </div>
      </form>
    </>
  )
}

export default Details
