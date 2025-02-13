import React from 'react'
import { NavLink } from 'react-router-dom'

function FormProject() {
  return (
    <>
      <div className="container">
        <div className="name">
            <label className="input-label" htmlFor="input">Project name</label>
            <input className="input" name="input"></input>
        </div>
        <div className="description">
            <label className="input-label" htmlFor="input">Description</label>
            <input className="input" name="input"></input>
        </div>
        <div className="manager">
            <label className="input-label" htmlFor="input">Manager</label>
            <input className="input" name="input"></input>
        </div>

        <div className="start-date">
            <label className="input-label" htmlFor="input">Start date</label>
            <input className="input" name="input"></input>
        </div>
        <div className="end-date">
            <label className="input-label" htmlFor="input">End date</label>
            <input className="input" name="input"></input>
        </div>
        <div className="customer">
            <label className="input-label" htmlFor="input">Customer</label>
            <input className="input" name="input"></input>
        </div>
        <div className="service">
            <label className="input-label" htmlFor="input">Service</label>
            <input className="input" name="input"></input>
        </div>
        <div className="status">
            <label className="input-label" htmlFor="input">Status</label>
            <input className="input" name="input"></input>
        </div>

        <NavLink to="/" className="btn save">Save</NavLink>
        <NavLink to="/" className="btn cancel">Cancel</NavLink>
      </div>
    </>
  )
}

export default FormProject
