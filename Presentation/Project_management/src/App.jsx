import React from 'react'
import Overview from './pages/Overview'
import Employees from './pages/Employees'
import Customers from './pages/Customers'
import AddProject from './pages/AddProject'
import ProjectDetails from './pages/ProjectDetails'
import Admin from './pages/Admin'
import { BrowserRouter, Routes, Route } from 'react-router-dom'

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Overview />} />
          <Route path="/employees" element={<Employees />} />
          <Route path="/customers" element={<Customers />} />
          <Route path="/addProject" element={<AddProject />} />
          <Route path="/projectDetails" element={<ProjectDetails />} />
          <Route path="/admin" element={<Admin />} />
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
