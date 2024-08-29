import React from "react";

const JobTabs: React.FC = () => {
  return (
    <div className="bg-white shadow-md py-6 mt-4">
      <div className="max-w-3xl mx-auto">
        <div className="flex justify-between border-b border-gray-300">
          <a href="#" className="pb-2 text-blue-600 border-blue-600 border-b-2">
            Jobs for you
          </a>
          <a href="#" className="pb-2 text-gray-600 hover:text-blue-600">
            Recent searches
          </a>
        </div>
        <div className="mt-6 text-center">
          <p className="text-gray-700">
            We're working on your personalized job feed.
          </p>
          <p className="text-gray-500 mt-2">
            In the meantime, run a search to find your next job.
          </p>
          <button className="mt-4 px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700">
            Find jobs
          </button>
        </div>
      </div>
    </div>
  );
};

export default JobTabs;
