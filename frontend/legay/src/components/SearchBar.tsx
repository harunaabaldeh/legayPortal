import React from "react";

const SearchBar: React.FC = () => {
  return (
    <div className="bg-white shadow-md -mt-10 relative z-10 py-4 px-4">
      <div className="max-w-3xl mx-auto flex flex-col md:flex-row space-y-4 md:space-y-0 md:space-x-4">
        <div className="flex-grow">
          <input
            type="text"
            placeholder="Job title, keywords, or company"
            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div className="flex-grow">
          <input
            type="text"
            placeholder="Remote"
            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <button className="bg-blue-600 text-white px-6 py-2 rounded-md hover:bg-blue-700">
          Search
        </button>
      </div>
    </div>
  );
};

export default SearchBar;
