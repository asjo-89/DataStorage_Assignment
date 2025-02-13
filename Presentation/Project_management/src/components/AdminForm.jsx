import React from 'react'
import { NavLink } from 'react-router-dom'

function AdminForm() {
  return (
    <>
      <div className="container-admin">
        <div className="card customer">
            <h2>Add new customer</h2>
            <label className="input-label" htmlFor="input">Customer name</label>
            <input className="input" name="input"></input>
            <label className="input-label" htmlFor="input">Phone number</label>
            <input className="input" name="input"></input>
            <label className="input-label" htmlFor="input">Email</label>
            <input className="input" name="input"></input>
            <NavLink to="/" className="btn save">Save</NavLink>
        </div>
        <div className="card manager">
            <h2>Add new manager</h2>
            <label className="input-label" htmlFor="input">Manager name</label>
            <input className="input" name="input"></input>
            <label className="input-label" htmlFor="input">Role</label>
            <input className="input" name="input"></input>
            <NavLink to="/" className="btn save">Save</NavLink>
        </div>
        <div className="card service">
            <h2>Add new service</h2>
            <label className="input-label" htmlFor="input">Service name</label>
            <input className="input" name="input"></input>
            <label className="input-label" htmlFor="input">Price</label>
            <input className="input" name="input"></input>
            <label className="input-label" htmlFor="input">Unit</label>
            <input className="input" name="input"></input>
            <NavLink to="/" className="btn save">Save</NavLink>
        </div>
        <div className="card status">
            <h2>Add new status</h2>
            <label className="input-label" htmlFor="input">Status name</label>
            <input className="input" name="input"></input>
            <NavLink to="/" className="btn save">Save</NavLink>
        </div>
        <div className="card role">
            <h2>Add new role</h2>
            <label className="input-label" htmlFor="input">Role name</label>
            <input className="input" name="input"></input>
            <NavLink to="/" className="btn save">Save</NavLink>
        </div>
      </div>
    </>
  )
}

export default AdminForm
