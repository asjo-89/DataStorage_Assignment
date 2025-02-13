import React, { useEffect, useState } from 'react'

function CustomersList() {

    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7273/api/customer')
        .then(response => response.json())
        .then(data => setCustomers(data))
        .catch(error =>
            console.error('Fetch failed: ', {error}))
    }, []);

  return (
    <>
        {customers.map((customer) => 
            <button key={customer.id} className="customer-mini">
                <h3>{customer.customerName}</h3>
                <p className="phonenumber">{customer.phoneNumber}</p>
                <p className="email">{customer.email}</p>
            </button>
        )}
    </>
  )
}

export default CustomersList
