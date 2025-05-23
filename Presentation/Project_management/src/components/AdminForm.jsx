import React, { useEffect, useState } from 'react'

function AdminForm() {

const [roles, setRoles] = useState([]);

useEffect(() => {
  fetchRoles();
}, []);

   const fetchRoles = async () => {
    try 
    {
      const response = await fetch('https://localhost:7273/api/role');
      if (!response.ok) {
        console.error('Failed to fetch roles:', response.data);
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

const customerSubmit = async (e) => {
  e.preventDefault();
  const form = new FormData(e.target);

  const customer = {
    CustomerName: form.get('customerName'),
    PhoneNumber: form.get('phoneNumber'),
    Email: form.get('email')
  };
  console.log(customer);
  const response = await fetch(`https://localhost:7273/api/customer/create`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(customer)
  });

  if (response.ok) {
    const data = await response.json();
    console.log('Customer added:', data);
  }
  else {
    console.error('Error adding customer:', response.statusText);
  }
}

const serviceSubmit = async (e) => {
  e.preventDefault();
  const form = new FormData(e.target);

  const service = {
    ServiceName: form.get('serviceName'),
    Price: form.get('price'),
    Unit: form.get('unit')
  };
  console.log(service);
  const response = await fetch(`https://localhost:7273/api/services/create`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(service)
  });

  if (response.ok) {
    const data = await response.json();
    console.log('Service added:', data);
  }
  else {
    console.error('Error adding service:', response.statusText);
  }
}

const statusSubmit = async (e) => {
  e.preventDefault();
  const form = new FormData(e.target);

  const status = {
    StatusName: form.get('statusName')
  };

  console.log(status);
  const response = await fetch(`https://localhost:7273/api/status`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(status)
  });

  if (response.ok) {
    const data = await response.json();
    console.log('Status added:', data);
  }
  else {
    console.error('Error adding status:', response.data);
  }
}

const managerSubmit = async (e) => {
  e.preventDefault();
  const form = new FormData(e.target);

  const manager = {
    FirstName: form.get('firstName'),
    LastName: form.get('lastName'),
    RoleId: form.get('role')
  };
  console.log(manager);
  const response = await fetch(`https://localhost:7273/api/employees`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(manager)
  });

  if (response.ok) {
    const data = await response.json();
    console.log('Manager added:', data);
  }
  else {
    console.error('Error adding manager:', response.statusText);
  }
}

const roleSubmit = async (e) => {
  e.preventDefault();
  const form = new FormData(e.target);

  const role = {
    RoleName: form.get('roleName')
  };
  console.log(role);
  const response = await fetch(`https://localhost:7273/api/role`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(role)
  });

  if (response.ok) {
    const data = await response.json();
    console.log('Role added:', data);
  }
  else {
    console.error('Error adding role:', response.statusText);
  }
}



  return (
    <>
      <div className="container-admin">
        <div className="card customer">
            <h2>Add new customer</h2>
            <form className="admin-form" onSubmit={customerSubmit}>
              <label className="input-label" htmlFor="customerName">Customer name</label>
              <input className="input" name="customerName" id="customerName"></input>
              <label className="input-label" htmlFor="phoneNumber">Phone number</label>
              <input className="input" name="phoneNumber"></input>
              <label className="input-label" htmlFor="email">Email</label>
              <input className="input" name="email"></input>
              <button type="submit" className="btn save">Save</button>
            </form>
        </div>
        <div className="card manager">
            <h2>Add new manager</h2>
            <form className="admin-form" onSubmit={managerSubmit}>
              <label className="input-label" htmlFor="firstName">First name</label>
              <input className="input" name="firstName" id="firstName"></input>
              <label className="input-label" htmlFor="lastName">Last name</label>
              <input className="input" name="lastName" id="lastName"></input>
              <label className="input-label" htmlFor="role">Role</label>
              <select className="input" name="role" id="role">
                <option value="" disabled>Select role</option>
                {roles.map((role) => (
                  <option key={role.id} value={role.id}>
                    {role.roleName}
                  </option>
                ))}
              </select>
              <button type="submit" className="btn save">Save</button>
            </form>
        </div>
        <div className="card service">
            <h2>Add new service</h2>            
            <form className="admin-form" onSubmit={serviceSubmit}>
              <label className="input-label" htmlFor="serviceName">Service name</label>
              <input className="input" name="serviceName" id="serviceName"></input>
              <label className="input-label" htmlFor="price">Price</label>
              <input className="input" name="price" id="price"></input>
              <label className="input-label" htmlFor="unit">Unit</label>
              <input className="input" name="unit" id="unit"></input>
              <button type="submit" className="btn save">Save</button>
            </form>
        </div>
        <div className="card status">
            <h2>Add new status</h2>
            <form className="admin-form" onSubmit={statusSubmit}>
              <label className="input-label" htmlFor="statusName">Status name</label>
              <input className="input" name="statusName" id="statusName"></input>
              <button type="submit" className="btn save">Save</button>
            </form>
        </div>
        <div className="card role">
            <h2>Add new role</h2>
            <form className="admin-form" onSubmit={roleSubmit}>
              <label className="input-label" htmlFor="roleName">Role name</label>
              <input className="input" name="roleName" id="roleName"></input>
              <button type="submit" className="btn save">Save</button>
            </form>
        </div>
      </div>
    </>
  )
}

export default AdminForm
