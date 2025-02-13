import React from 'react'

function Details() {
  return (
    <>
      <div className="card-1">
        <div className="title-box">
          <h2 className="title-1">P-101 - Project name</h2>
          <button className="edit">
            <img src="../images/pencil-solid.svg" alt="A pencil." />
          </button>
          <p className="text-1">2025-01-01 / 2025-03-01</p>
        </div>
        <div className="description-box">
          <h3 className="title">Description</h3>
          <p className="text description">Jadda jadda jadda</p>
        </div>
        <div className="manager">
          <h3 className="title">Manager: <p className="text manager-name">Hasse Aro</p></h3>
        </div>
      </div>

      <div className="card-2">
        <div className="details-group-4">
          <h3 className="title">Customer</h3>
          <p className="text">Tina Turner</p>
          <h3 className="title">Phone number</h3>
          <p className="text">12345</p>
          <h3 className="title">Email</h3>
          <p className="text">tina@domain.com</p>
        </div>
      </div>

      <div className="card-3">
        <div className="details-group-5">
          <h3 className="title">Service</h3>
          <p className="text">Web developement 1000 kr/tim</p>
        </div>
        <div className="details-group-6">
          <h3 className="title">Status</h3>
          <p className="text">Ongoing</p>
        </div>
      </div>
    </>
  )
}

export default Details
