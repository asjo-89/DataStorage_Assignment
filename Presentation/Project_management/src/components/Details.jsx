import React from 'react'

function Details() {
  return (
    <>
      <div className="card-1">
        <div className="title-box">
          <p className="title-1">P-101 - Project name</p>
          <button className="edit">
            <img src="../images/pencil-solid.svg" alt="A pencil." />
          </button>
          <p className="text-1">2025-01-01 / 2025-03-01</p>
        </div>
        <div className="description-box">
          <p className="title">Description</p>
          <p className="text description">Jadda jadda jadda</p>
        </div>
        <div className="manager">
          <p className="title">Manager: <span className="text manager-name">Hasse Aro</span></p>
        </div>
      </div>

      <div className="card-2">
        <div className="details-group-4">
          <p className="title">Customer</p>
          <p className="text">Tina Turner</p>
          <p className="title">Phone number</p>
          <p className="text">12345</p>
          <p className="title">Email</p>
          <p className="text">tina@domain.com</p>
        </div>
      </div>

      <div className="card-3">
        <div className="details-group-5">
          <p className="title">Service</p>
          <p className="text">Web developement 1000 kr/tim</p>
          </div>
          <div className="details-group-6">
          <p className="title">Status</p>
          <p className="text">Ongoing</p>
        </div>
      </div>
    </>
  )
}

export default Details
