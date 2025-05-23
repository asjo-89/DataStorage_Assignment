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
    fetchRoles();
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
      setEmployees(data);
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
      setStatuses(data);
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
      setServices(data);
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
      setCustomers(data);
    } 
    catch (error) 
    {
      console.error('Error fetching customers:', error);
    }
  }

const fetchRoles = async () => {
    try {
      const response = await fetch('https://localhost:7273/api/role');
      if (!response.ok) {
        console.error('Failed to fetch roles:', response.statusText);
        return;
      }
      const data = await response.json();
      setRoles(data);
    } 
    catch (error) 
    {
      console.error('Error fetching roles:', error);
    }
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
              {employees.map((employee) => (
                <option key={employee.id} value={employee.id}>{employee.firstName} {employee.lastName}</option>
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
              {customers.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.customerName}
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
              {services.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName} {service.price} {service.unit}
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
              {statuses.map((status) => (
                <option key={status.id} value={status.id}>
                  {status.statusName}
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
