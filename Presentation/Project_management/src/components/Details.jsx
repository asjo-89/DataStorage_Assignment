import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';

function Details({project, errors}) {

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

 const {
       register,
       handleSubmit,
       setError,
       formState: { errors: formErrors },
     } = useForm();

  useEffect(() => {
    const button = document.querySelector('.btn');
    if (button) {
      button.blur();
    }
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
      })
      
      sessionStorage.setItem("projectData", JSON.stringify(project));
    }
    else {
      const storedData = sessionStorage.getItem("projectData");
      if(storedData) {
        setEditedProject(JSON.parse(storedData));
      }
    }
}, [project]);

useEffect(() => {
  fetchCustomers();
  fetchEmployees();
  fetchServices();
  fetchStatuses();
}, []);

const navigate = useNavigate();

 const fetchEmployees = async () => {
    try 
    {
      const response = await fetch('https://localhost:7273/api/employees');
      if (!response.ok) {
        console.error('Failed to fetch managers:', response.data);
        return;
      }
      const data = await response.json();
      setEditedEmployee(data);
    }
    catch (error) 
    {
      console.error('Error fetching managers:', error);
    }
 }
 
  const fetchStatuses = async () => {
    try 
    {
      const response = await fetch('https://localhost:7273/api/status');
      if (!response.ok) {
        console.error('Failed to fetch statuses:', response.data);
        return;
      }
      const data = await response.json();
      setEditedStatus(data);
    } 
    catch (error) 
    {
      console.error('Error fetching statuses:', error);
    }
  }

const fetchServices = async () => {
    try 
    {
      const response = await fetch('https://localhost:7273/api/services');
      if (!response.ok) {
        console.error('Failed to fetch services:', response.data);
        return;
      }
      const data = await response.json();
      setEditedService(data);
    } 
    catch (error) 
    {
      console.error('Error fetching services:', error);
    }
  }

  const fetchCustomers = async () => {
    try 
    {
      const response = await fetch('https://localhost:7273/api/customer');
      if (!response.ok) {
        console.error('Failed to fetch customers:', response.data);
        return;
      }
      const data = await response.json();
      setEditedCustomer(data);
    } 
    catch (error) 
    {
      console.error('Error fetching customers:', error);
    }
  }

  const handleSave = async () => {
      if (isEditing) 
      {
        await onSubmit();
      }      
      setIsEditing(!isEditing);
  }

  const handleGoBack = () => {
    if(isEditing) {
      setIsEditing(!isEditing);
    }
    else {
      navigate("/");
    }
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

  const onSubmit = async () => {
    console.log("Edited project before sending:", editedProject);

    const fields = {
      ...editedProject,
      customerId: Number(editedProject.customerId),
      employeeId: Number(editedProject.employeeId),
      statusInformationId: Number(editedProject.statusInformationId),
      serviceId: Number(editedProject.serviceId),
    };

    console.log("Sending data:", fields);

    try {
      const response = await fetch(`https://localhost:7273/api/project/${editedProject.id}`, {
        method: "PUT",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(fields)
      });
      
      if (!response.ok) {
        console.log("Failed to update changes", JSON.stringify(fields));
      }

      const data = await response.json();
      console.log("Update successful.", data);
      setEditedProject({
        ...editedProject,
        ...data,
        // Behåll relationer (om de är annorlunda i svaret)
        employee: data.employee || editedProject.employee,
        customer: data.customer || editedProject.customer,
        service: data.service || editedProject.service,
        statusInformation: data.statusInformation || editedProject.statusInformation,
      });
    }
    catch (error) {
      console.log("Update failed: ", {error});
    }
  }

const handleChange = (e) => {
  const { name, value } = e.target;
  const numberFields = ["customerId", "employeeId", "statusInformationId", "serviceId"].includes(name);
  const newValue = numberFields ? Number(value) : value;

  setEditedProject((prev) => {
    const updated = {
      ...prev,
      [name]: newValue,
    };

    if (name === "customerId") {
      const customer = editedCustomer.find(c => c.id === Number(value));
      updated.customer = customer || "";
      updated.customerId = customer ? customer.id : "";
    }

    if (name === "serviceId") {
      const selectedService = editedService.find(service => service.id === Number(value));
      if (selectedService) {
        updated.service = {
          id: selectedService.id,
          serviceName: selectedService.serviceName,
          price: selectedService.price,
          unit: selectedService.unit || "",
        };
        updated.serviceId = selectedService.id;
      }
    }

    return updated;
  });

  console.log("edited", editedProject);
};


  return (
    <>
    <form className="container" onSubmit={onSubmit} >
      <div className="card-1">
        <div className="title-box">
          <h2 className="title-1">{editedProject.id || ""} - {isEditing ? (
            <>
              <input className="input" type="text" name="projectTitle" value={editedProject.projectTitle || ""} onChange={handleChange} 
                // {...register("projectTitle")}
              />
              {formErrors.projectTitle && (<p class="error">{formErrors.projectTitle?.message}</p>)}
            </>
            ) : (editedProject.projectTitle || "")}</h2>  
          <p className="text-1">
          {isEditing ? (
            <>
              <input className="input" type="date" name="startDate" value={editedProject.startDate || ""} onChange = {handleChange} 
                // {...register("startDate")} 
              />
                {formErrors.startDate && <p class="error">{formErrors.startDate?.message}</p>}
                - 
              <input className="input" type="date"name="endDate" value={editedProject.endDate || ""} onChange = {handleChange} 
                // {...register("endDate")} 
              />
                {formErrors.endDate && <p class="error">{formErrors.endDate?.message}</p>}
            </>)
          : (`${editedProject.startDate || ""} - ${editedProject.endDate || ""}`)}</p>
        </div>

        <div className="description-box">
          <h3 className="title">Description</h3>
            {isEditing ? (
              <>
                <textarea className="input description" type="text"  name="description"
                  value={editedProject.description || ""} onChange = {handleChange}
                  // {...register("description")}  
                />
                  {formErrors.description && <p class="error">{formErrors.description?.message}</p>}
              </>
              ) 
              : <p className="text description">{editedProject.description || ""}</p>}
        </div>

        <div className="manager">
          <h3 className="title">Manager: 
            {isEditing ? (
              <>
                <select className="input manager-opt" type="text"  name="employeeId"
                  value={editedProject.employeeId} onChange = {handleChange}
                  // {...register("employeeId")}  
                >
                  {editedEmployee.map((employee) => (
                  <option key={employee.id} value={employee.id}>
                    {employee.firstName} {employee.lastName}
                  </option>
                  ))}
                </select>
                {formErrors.employeeId && <p class="error">{formErrors.employeeId.message}</p>}
              </>
              ) 
              : (<p className="text manager-name">{editedProject.employee ? `${editedProject.employee.firstName} ${editedProject.employee.lastName}` : ""}</p>)}
          </h3>
        </div>
        <div className="buttons">
          <button className={`btn ${isEditing ? "save" : "edit"}`} type="button" onClick={handleSave}>
            {isEditing ? "Save" : "Edit"}
          </button>
          <button className="btn delete" type="button" onClick={handleDelete}>
            Delete
          </button>
          <button className="btn cancel" onClick={handleGoBack}>
            {isEditing ? "Cancel" : "Go back"}
          </button>
        </div>
      </div>

      <div className="card-2">
          <h3 className="title">Customer</h3>
          {isEditing ? (
            <>
              <select className="input customer-opt" type="text" name="customerId"
                value={editedProject.customerId} 
                onChange={handleChange}
                // {...register("customerId")}  
              >
                {editedCustomer.map((customer) => (
                  <option key={customer.id} value={customer.id}>
                    {customer.customerName}
                  </option>
                ))}
              </select>
              {formErrors.customerId && <p class="error">{formErrors.customerId.message}</p>}
            </>
          )
          : (<p className="text">{editedProject.customer ? `${editedProject.customer.customerName}` : ""}</p>)}

          <h3 className="title">Phone number</h3>
          <p className="text">{editedProject.customer.phoneNumber || ""}</p>

          <h3 className="title">Email</h3>
          <p className="text">{editedProject.customer.email || ""}</p>
       
      </div>

      <div className="card-3">
        <h3 className="title">Service</h3>
        {isEditing ? (
          <>
            <select className="input service-opt" type="text" name="serviceId"
            value={editedProject.serviceId} 
            onChange={handleChange}
            // {...register("serviceId")}  
            >
              {editedService.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName} {service.price} {service.unit}
                </option>
              ))}
            </select>
            {formErrors.serviceId && <p class="error">{formErrors.serviceId.message}</p>}
          </>
          )
          : (<p className="text">{editedProject.service ? `${editedProject.service.serviceName} - ${editedProject.service.price} ${editedProject.service.unit}` : ""}</p>)}
          
        <h3 className="title">Status</h3>
        {isEditing ? (
          <>
            <select className="input status-opt" type="text" name="statusInformationId"
              value={editedProject.statusInformationId} 
              onChange={handleChange}
              // {...register("statusInformationId")}  
            >
                {editedStatus.map((status) => (
                  <option key={status.id} value={status.id}>
                    {status.statusName}
                  </option>
                ))}
            </select>
            {formErrors.statusInformationId && <p class="error">{formErrors.statusInformationId.message}</p>}
          </>
        )
          : (<p className="text">{editedProject.statusInformation.statusName || ""}</p>)}
        </div>
      </form>
    </>
  )
}

export default Details
