import React, { useEffect, useState } from 'react';
import ProjectCards from './ProjectCards';
import { useForm } from 'react-hook-form';

function ProjectList() {

  const [projects, setProjects] = useState([]);
  const {
    register,
    onSubmit,
    setError,
    formState: { errors },
  } = useForm();

  
  useEffect(() => {
    fetchProjects();
  }, []);

    const fetchProjects = async () => {
    try 
    {
      const response = await fetch(`https://localhost:7273/api/project`);
      if (!response.ok) {
        console.error('Failed to fetch projects:', response.data);
        return;
      }
      const data = await response.json();
      console.log('Fetched projects:', data);
      setProjects(data);
    }
    catch (error) 
    {
      console.error('Error fetching projects:', error);
    }
 }
  

//Behöver kopplas på bättre sätt till statusinformation ifall status får nytt id.

  return (
    <>
        <ProjectCards classname="ongoing" title="Ongoing" projects={projects.filter(p => p.statusInformation.statusName === "Ongoing")} errors={errors} />
        <ProjectCards classname="not-started" title="Not started" projects={projects.filter(p => p.statusInformation.statusName === "Not started")} errors={errors} />
        <ProjectCards classname="completed" title="Completed" projects={projects.filter(p => p.statusInformation.statusName === "Completed")} errors={errors} />
    </>
  )
}

export default ProjectList
