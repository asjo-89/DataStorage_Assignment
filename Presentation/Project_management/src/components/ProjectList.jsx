import React, { useEffect, useState } from 'react'
import { NavLink } from 'react-router-dom';

function ProjectList() {
  const [projects, setProjects] = useState([]);
  const [statuses, setStatuses] = useState([]);
  const [customers, setCustomers] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [services, setServices] = useState([]);

  useEffect(() => {
    fetchProjects();
  }, []);

  const fetchProjects = async () => {
    try {
      const response = await fetch('https://localhost:7273/api/project');
      const data = await response.json();
      setProjects(data);
      console.log('projects',data)
      const statusIds = [...new Set(data.map(proj => proj.statusInformationId))];
      fetchStatuses(statusIds);
      const customerIds = [...new Set(data.map(proj => proj.customerId))];
      fetchCustomers(customerIds);
      const employeeIds = [...new Set(data.map(proj => proj.employeeId))];
      console.log(`EmployeeIds: ${employeeIds}`);
      fetchEmployees(employeeIds);
      const serviceIds = [...new Set(data.map(proj => proj.serviceId))];
      fetchServices(serviceIds);
    }
    catch (error) {
      console.error("Failed fetching projects: ", error);
    }
  }

  const fetchStatuses = async (statusIds) => {
    try {
      const response = await Promise.all(
        statusIds.map(id => fetch(`https://localhost:7273/api/statusinformation/${id}`))
      );
      const data = await Promise.all(response.map(res => res.json()));
      
      const statuses = {};
      data.forEach(status => {
        statuses[status.id] = status.statusName;
      });
      setStatuses(statuses);
    }
    catch (error) {
      console.error("Failed fetching status information: ", error);
    }
  }

  const fetchCustomers = async (customerIds) => {
    try {
      const response = await Promise.all(
        customerIds.map(id => fetch(`https://localhost:7273/api/customer/${id}`))
      );
      const data = await Promise.all(response.map(res => res.json()));

      const customers = {};
      data.forEach(customer => {
        customers[customer.id] = {
          customerName: customer.customerName,
          phoneNumber: customer.phoneNumber,
          email: customer.email
        };
      });
      console.log(customers);
      setCustomers(customers);
    }
    catch (error) {
      console.error("Failed fetching customers: ", error);
    }
  }

  const fetchEmployees = async (employeeIds) => {
    try {
      const response = await Promise.all(
        employeeIds.map(id => fetch(`https://localhost:7273/api/employee/${id}`))
      );
      const data = await Promise.all(response.map(res => res.json()));

      const employees = {};
      data.forEach(employee => {
        employees[employee.id] = `${employee.firstName} ${employee.lastName}`;
      });
      setEmployees(employees);
    }
    catch (error) {
      console.error("Failed fetching employees: ", error);
    }
  }

  const fetchServices = async (serviceIds) => {
    try {
      const response = await Promise.all(
        serviceIds.map(id => fetch(`https://localhost:7273/api/services/${id}`))
      );
      const data = await Promise.all(response.map(res => res.json()));

      const services = {};
      data.forEach(service => {
        services[service.id] = {
          serviceName: service.serviceName,
          price: service.price,
          unit: service.unit
        };
      });
      setServices(services);
    }
    catch (error) {
      console.error("Failed fetching services: ", error);
    }
  }

  return (
    <>
        <div className="ongoing">
            <div className="title">
              <h2>Ongoing</h2>
            </div>
            {projects
              .filter((project) => (project.statusInformationId == 1))
              .map((project) => (
              <NavLink to="/projectDetails" state={{project: project, customer: customers[project.customerId], customers: customers, employee: employees[project.employeeId], employees: employees,  services: services, statuses: statuses}} key={project.id} className="project-mini">
                <h3 className="project-name">{project.id} - {project.title}</h3>
                <p className="date">{project.startDate} - {project.endDate}</p>
                <p className="manager">{employees[project.employeeId] ?? "Unknown"}</p>
                <p className="customer">{customers[project.customerId]?.customerName ?? "Unknown"}</p>
              </NavLink>
            ))}
        </div>

        <div className="not-started">
            <div className="title">
              <h2>Not started</h2>
            </div>
            {projects
              .filter((project) => (project.statusInformationId == 2))
              .map((project) => (
                <NavLink to="/projectDetails" state={{project: project, customer: customers[project.customerId]}} key={project.id} className="project-mini">
                  <h3 className="project-name">{project.id} - {project.title}</h3>
                  <p className="date">{project.startDate} - {project.endDate}</p>
                  <p className="manager">{employees[project.employeeId] ?? "Unknown"}</p>
                  <p className="customer">{customers[project.customerId]?.customerName ?? "Unknown"}</p>
                </NavLink>
              ))}
        </div>

        <div className="completed">
            <div className="title">
              <h2>Completed</h2>
            </div>
            {projects
              .filter((project) => (project.statusInformationId == 3))
              .map((project) => (
                <NavLink to="/projectDetails" state={{project: project, customer: customers[project.customerId]}} key={project.id} className="project-mini">
                  <h3 className="project-name">{project.id} - {project.title}</h3>
                  <p className="date">{project.startDate} - {project.endDate}</p>
                  <p className="manager">{employees[project.employeeId] ?? "Unknown"}</p>
                  <p className="customer">{customers[project.customerId]?.customerName ?? "Unknown"}</p>
                </NavLink>
              ))}
        </div>
    </>
  )
}

export default ProjectList
