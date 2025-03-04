import React, { useEffect, useState } from 'react';
import ProjectCards from './ProjectCards';

function ProjectList() {

  const [projects, setProjects] = useState([]);
  
  useEffect(() => {
    fetchProjects();
  }, []);

  const fetchProjects = async () => {
    try {
      const response = await fetch("https://localhost:7273/api/project");
      const data = await response.json();
      setProjects(data);
      console.log("fetch", {data})
    }
    catch (error) {
      console.log("fetching projects failed", {error});
    }
  }
  

//Behöver kopplas på bättre sätt till statusinformation ifall status får nytt id.

  return (
    <>
        <ProjectCards classname="ongoing" title="Ongoing" projects={projects.filter(p => p.statusInformationId === 1)} />
        <ProjectCards classname="not-started" title="Not started" projects={projects.filter(p => p.statusInformationId === 5)} />
        <ProjectCards classname="completed" title="Completed" projects={projects.filter(p => p.statusInformationId === 3)} />
    </>
  )
}

export default ProjectList
