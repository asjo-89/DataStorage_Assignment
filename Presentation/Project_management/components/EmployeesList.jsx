import React, { useEffect, useState } from 'react'

function EmployeesList() {

    const [employees, setEmployees] = useState([]);
    const [roles, setRoles] = useState([]); 
  
    useEffect(() => {
      fetchEmployees();
    }, []);
  
    const fetchEmployees = async () => {
      try {
        const response = await fetch('https://localhost:7273/api/employees');
        const data = await response.json();
        setEmployees(data);
  
        const roleIds = [...new Set(data.map(emp => emp.roleId))];
        fetchRoles(roleIds);
      } catch (error) {
        console.error('Error fetching employees:', error);
      }
    };
  
    const fetchRoles = async (roleIds) => {
      try {
        const responses = await Promise.all(
          roleIds.map(id => fetch(`https://localhost:7273/api/role/${id}`))
        );
        const data = await Promise.all(responses.map(res => res.json()));
  
        const roles = {};
        data.forEach(role => {
          roles[role.id] = role.roleName;
        });
  
        setRoles(roles);
      } catch (error) {
        console.error('Error fetching roles:', error);
      }
    };
  
    return (
      <>
        {employees.map((employee) => (
          <div key={employee.id} className="employee-mini">
            <h3>{employee.firstName} {employee.lastName}</h3>
            <h4 className="projects">{roles[employee.roleId] || "Unknown Role"}</h4>
          </div>
        ))}
      </>
    );
  }


export default EmployeesList
