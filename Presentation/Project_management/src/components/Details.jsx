import React, { useEffect, useState } from 'react'
import { NavLink, useNavigate } from 'react-router-dom'

function Details({project}) {

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


  useEffect(() => {
    if (project)
    {
      setEditedProject({
        id: Number(project.id),
        projectTitle: project.projectTitle || "",
        description: project.description || "",
        startDate: project.startDate?.split("T")[0] ?? "",
        endDate: project.endDate?.split("T")[0] ?? "",
        statusInformationId: Number(project.statusInformationId),
        statusInformation: {
          id: project.statusInformationId,
          statusName: project.statusInformation.statusName
        },
        employeeId: Number(project.employeeId),
        employee: {
          id: project.employeeId,
          firstName: project.employee.firstName,
          lastName: project.employee.lastName,
          role: { id: project.employee.roleId, roleName: project.employee.role.roleName }
        },
        customerId: Number(project.customerId),
        customer: {
          id: project.customerId,
          customerName: project.customer.customerName,
          phoneNumber: project.customer.phoneNumber,
          email: project.customer.email
        },
        serviceId: Number(project.serviceId),
        service: {
          id: project.serviceId,
          serviceName: project.service.serviceName,
          price: project.service.price,
          unit: project.service.unit
        }
    })};

}, [project]);

useEffect(() => {
  fetchCustomers();
  fetchEmployees();
  fetchServices();
  fetchStatuses();
}, []);

const navigate = useNavigate();

  const fetchEmployees = async () => {
    const response = await fetch("https://localhost:7273/api/employee");
    const data = await response.json();
    setEditedEmployee(data);
  }                                     

  const fetchCustomers = async () => {
    const response = await fetch("https://localhost:7273/api/customer");
    const data = await response.json();
    setEditedCustomer(data);
  } 

  const fetchServices = async () => {
    const response = await fetch("https://localhost:7273/api/services");
    const data = await response.json();
    setEditedService(data);
  } 
  
  const fetchStatuses = async () => {
    const response = await fetch("https://localhost:7273/api/statusInformation");
    const data = await response.json();
    setEditedStatus(data);
  } 
  const handleSave = async (e) => {
      if (isEditing) 
      {
        await handleSubmit(e);
      }      
      setIsEditing(!isEditing);
  }

  const handleDelete = async (e) => {
    const confirmDelete = window.confirm("Are you sure you want to delete this project?");
    if (!confirmDelete) return;

    try 
    {
      const response = await fetch(`https://localhost:7273/api/project/${editedProject.id}`, {
        method: "DELETE"
      });

      if (!response.ok) {
        const errorMessage = await response.text(); // Läs felmeddelande från backend
        console.error(`Failed to delete project: ${response.status} - ${errorMessage}`);
        return;
      }

      console.log("Project deleted successfully");
      navigate('/');
    }
    catch (error) 
    {
      console.log("Delete failed: ", {error});
    }
  }

  const handleSubmit = async (e) => {
    e.preventDefault();

    console.log("Edited project before sending:", editedProject);

    const fieldNotEmpty = Object.fromEntries(
      Object.entries(editedProject).map(([key, value]) => {
        if (["customerId", "employeeId", "statusInformationId", "serviceId"].includes(key)) {
          return [key, value ? Number(value) : null];
        }
        return [key, value === "" ? null : value];
      })
    );

    fieldNotEmpty.employee = editedProject.employee;

    console.log("Sending data to API:", fieldNotEmpty);

    try {
      const response = await fetch(`https://localhost:7273/api/project/${editedProject.id}`, {
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
      console.log("Update failed: ", {error});
    }
  }

  const handleChange = (e) => {
    const value = e.target.value;
    const name = e.target.name;    
    if (name === "customerId" || name === "employeeId" || name === "statusInformationId" || name === "serviceId") {
      const numValue = Number(value);
      setEditedProject((prev) => ({
        ...prev,
        [name]: numValue, 
      }));
    } else {
      setEditedProject((prev) => ({
        ...prev,
        [name]: value,
      }));
    }
    if (name === "customerId") {
      const customer = editedCustomer.find(c => c.id == Number(value));

      setEditedProject((prev) => ({
        ...prev,
        customerId: value,
        customer: customer 
      }));
    }
    if (name === "serviceId") {
      const selectedService = editedService.find(service => service.id === Number(value));
      setEditedProject(prev => ({
        ...prev,
        serviceId: value,
        service: {
          id: selectedService.id,
          serviceName: selectedService.serviceName,
          price: selectedService.price,
          unit: selectedService ? selectedService.unit : "", 
    }}));
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
                value={editedProject.employeeId} onChange = {handleChange}>
                {editedEmployee.map((employee) => (
                <option key={employee.id} value={employee.id}>
                  {employee.firstName} {employee.lastName}
                </option>
                ))}
              </select>
              ) 
              : (<p className="text manager-name">{editedProject.employee ? `${editedProject.employee.firstName} ${editedProject.employee.lastName}` : ""}</p>)}
          </h3>
        </div>
        <div className="buttons">
          <button className="btn save" type="button" onClick={handleSave}>
            {isEditing ? "Save" : "Edit"}
          </button>
          <button className="btn delete" type="button" onClick={handleDelete}>
            Delete
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
          : (<p className="text">{editedProject.customer ? `${editedProject.customer.customerName}` : ""}</p>)}

          <h3 className="title">Phone number</h3>
          <p className="text">{editedProject.customer.phoneNumber || ""}</p>

          <h3 className="title">Email</h3>
          <p className="text">{editedProject.customer.email || ""}</p>
       
      </div>

      <div className="card-3">
        <h3 className="title">Service</h3>
        {isEditing ? (
            <select className="input service-opt" type="text" name="serviceId"
            value={editedProject.serviceId} 
            onChange={handleChange}>
              {editedService.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName} {service.price} {service.unit}
                </option>
              ))}
            </select>)
          : (<p className="text">{editedProject.service ? `${editedProject.service.serviceName} - ${editedProject.service.price} ${editedProject.service.unit}` : ""}</p>)}
          
        <h3 className="title">Status</h3>
        {isEditing 
          ? (
          <select className="input status-opt" type="text" name="statusInformationId"
            value={editedProject.statusInformationId} 
            onChange={handleChange}>
              {editedStatus.map((status) => (
                <option key={status.id} value={status.id}>
                  {status.statusName}
                </option>
              ))}
          </select>)
          : (<p className="text">{editedProject.statusInformation.statusName || ""}</p>)}
        </div>
      </form>
    </>
  )
}

export default Details
