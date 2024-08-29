import { useEffect, useState } from "react";
import agent from "../api/agent";
import { Job } from "../models/job";

const JobsList = () => {
  const [jobs, setJobs] = useState<Job[]>([]);

  useEffect(() => {
    agent
      .get("/api/jobs")
      .then((res) => {
        setJobs(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div>
      {jobs.map((job) => {
        return (
          <ul>
            <li key={job.id}>{job.title}</li>
          </ul>
        );
      })}
    </div>
  );
};

export default JobsList;
