import React, { useState, useEffect } from 'react'
import { NavLink, useNavigate } from 'react-router-dom'

function FormProject() {
  const [inputs, setInputs] = useState({
    projectTitle: "",
    description: "",
    startDate: "",
    endDate: "",
    statusInformationId: "",
    employeeId: "",
    customerId: "",
    serviceId: ""
  });
  const [statuses, setStatuses] = useState([]);
  const [services, setServices] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    fetchStatuses();
    fetchServices();
    fetchEmployees();
    fetchCustomers();
  }, []);

  const navigate = useNavigate();

  const fetchStatuses = async () => {
    const response = await fetch("https://localhost:7273/api/statusInformation");
    const data = await response.json();
    setStatuses(data);
  }
  
  const fetchServices = async () => {
    const response = await fetch("https://localhost:7273/api/services");
    const data = await response.json();
    setServices(data);
  }

  const fetchEmployees = async () => {
    const response = await fetch("https://localhost:7273/api/employee");
    const data = await response.json();
    setEmployees(data);
  }

  const fetchCustomers = async () => {
    const response = await fetch("https://localhost:7273/api/customer");
    const data = await response.json();
    setCustomers(data);
  }
  
  const handleSubmit = async (e) => {
    e.preventDefault();
    const fieldNotEmpty = Object.fromEntries(
      Object.entries(inputs).map(([key, value]) => [key, value === "" ? null : value])
    );
    try {
      const response = await fetch(`https://localhost:7273/api/project/`, {
        method: "post",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(fieldNotEmpty)
      });
      if(!response.ok) {
        console.log("Failed to post inputs ", JSON.stringify(fieldNotEmpty));
        return;
      }

      const data = await response.json();
      console.log("POST succeeded: ", {data});

      navigate("/");
    }
    catch (error) {
      console.log({error})
    }
  }

  const handleChange = (e) => {
    let value = e.target.value;
    let name = e.target.name;
    setInputs({...inputs, [name]: value});
    console.log(inputs);
  }
  
  const employeeList = employees 
    ? employees.map((employee) => (
      {
        id: employee.id, 
        name: `${employee.firstName} ${employee.lastName}`
      }))
    : [];

  const customerList = customers
    ? customers.map((customer) => (
      {
        id: customer.id, 
        name: customer.customerName
      }))
    : [];

    const statusList = statuses
      ? statuses.map((status) => (
        {
          id: status.id, 
          name: status.statusName
        }))
      : [];

    const serviceList = services  
      ? services.map((service) => (
        {
          id: service.id, 
          name: service.serviceName,
          price: service.price,
          unit: service.unit
        }))
      : [];


  return (
    <>
        <form className="container" onSubmit={handleSubmit}>
          <div className="name">
            <label className="input-label" htmlFor="projectTitle"> Project name * </label>
            <input className="input" type="text" name="projectTitle" value={inputs.projectTitle} onChange={handleChange} />
          </div>

          <div className="description">
            <label className="input-label" htmlFor="description"> Description * </label>
            <textarea className="input" type="text" name="description" value={inputs.description} onChange={handleChange} />
          </div>

          <div className="manager">
            <label className="input-label" htmlFor="employeeId"> Manager * </label>
            <select className="input" type="text" name="employeeId" value={inputs.employeeId} onChange={handleChange}>
              <option value="" disabled>
                Choose manager...
              </option>
              {employeeList.map((employee) => (
                <option key={employee.id} value={employee.id}>{employee.name}</option>
              ))}              
            </select>                
          </div>

          <div className="start-date">
            <label className="input-label" htmlFor="startDate"> Start date </label>
            <input className="input" type="date" name="startDate" value={inputs.startDate} onChange={handleChange} />
          </div>

          <div className="end-date">
            <label className="input-label" htmlFor="endDate"> End date </label>
            <input className="input" type="date" name="endDate" value={inputs.endDate} onChange={handleChange} />
          </div>

          <div className="customer">
            <label className="input-label" htmlFor="customerId"> Customer * </label>
            <select className="input" type="text" name="customerId" value={inputs.customerId} onChange={handleChange}>
            <option value="" disabled>
                Choose customer...
              </option>
              {customerList.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.name}
                </option>
              ))}
            </select>
          </div>

          <div className="service">
            <label className="input-label" htmlFor="serviceId"> Service * </label>
            <select className="input" type="text" name="serviceId" value={inputs.serviceId} onChange={handleChange}>
            <option value="" disabled>
                Choose service...
              </option>
              {serviceList.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.name} {service.price} {service.unit}
                </option>
              ))}
            </select>
          </div>

          <div className="status">
            <label className="input-label" htmlFor="statusInformationId"> Status * </label>
            <select className="input" type="text" name="statusInformationId" value={inputs.statusInformationId} onChange={handleChange}>
            <option value="" disabled>
                Choose status...
              </option>
              {statusList.map((status) => (
                <option key={status.id} value={status.id}>
                  {status.name}
                </option>
              ))}
            </select>
          </div>
          
          <button type="submit" className="btn save">Save</button>
          <NavLink to="/" className="btn cancel">Cancel</NavLink>
        </form>
    </>
  )
}

export default FormProject
