import React from "react";

const Navbar: React.FC = () => {
  return (
    <nav className="bg-white shadow-sm">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex justify-between items-center py-4">
        <div className="flex items-center space-x-4">
          <img
            src="path_to_logo" // Replace with your logo path
            alt="Logo"
            className="h-8"
          />
          <div className="hidden md:flex space-x-6">
            <a href="#" className="text-gray-700 hover:text-blue-600">
              Home
            </a>
            <a href="#" className="text-gray-700 hover:text-blue-600">
              Company reviews
            </a>
            <a href="#" className="text-gray-700 hover:text-blue-600">
              Find salaries
            </a>
          </div>
        </div>
        <div className="hidden md:flex space-x-6">
          <a href="#" className="text-gray-700 hover:text-blue-600">
            Sign in
          </a>
          <a
            href="#"
            className="text-blue-600 hover:text-blue-700 border-blue-600 border rounded-full px-4 py-2"
          >
            Employers / Post Job
          </a>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
