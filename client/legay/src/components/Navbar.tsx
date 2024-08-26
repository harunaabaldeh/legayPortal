import { useState } from "react";

const Navbar: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <nav className="bg-white shadow-md fixed w-full z-10">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-16">
          <div className="flex items-center">
            <a href="#" className="text-xl font-bold text-gray-800">
              JobFinder
            </a>
          </div>
          <div className="flex items-center">
            <div className="hidden md:block">
              <div className="ml-10 flex items-baseline space-x-4">
                <a
                  href="#"
                  className="text-gray-800 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
                >
                  Home
                </a>
                <a
                  href="#"
                  className="text-gray-800 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
                >
                  Jobs
                </a>
                <a
                  href="#"
                  className="text-gray-800 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
                >
                  Companies
                </a>
                <a
                  href="#"
                  className="text-gray-800 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
                >
                  About
                </a>
                <a
                  href="#"
                  className="text-gray-800 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
                >
                  Contact
                </a>
              </div>
            </div>
            <div className="md:hidden">
              <button
                onClick={toggleMenu}
                className="text-gray-800 hover:text-blue-600 focus:outline-none"
              >
                <svg
                  className="h-6 w-6"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d={
                      isOpen
                        ? "M6 18L18 6M6 6l12 12"
                        : "M4 6h16M4 12h16M4 18h16"
                    }
                  />
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>
      {isOpen && (
        <div className="md:hidden">
          <div className="px-2 pt-2 pb-3 space-y-1 sm:px-3">
            <a
              href="#"
              className="text-gray-800 hover:text-blue-600 block px-3 py-2 rounded-md text-base font-medium"
            >
              Home
            </a>
            <a
              href="#"
              className="text-gray-800 hover:text-blue-600 block px-3 py-2 rounded-md text-base font-medium"
            >
              Jobs
            </a>
            <a
              href="#"
              className="text-gray-800 hover:text-blue-600 block px-3 py-2 rounded-md text-base font-medium"
            >
              Companies
            </a>
            <a
              href="#"
              className="text-gray-800 hover:text-blue-600 block px-3 py-2 rounded-md text-base font-medium"
            >
              About
            </a>
            <a
              href="#"
              className="text-gray-800 hover:text-blue-600 block px-3 py-2 rounded-md text-base font-medium"
            >
              Contact
            </a>
          </div>
        </div>
      )}
    </nav>
  );
};

export default Navbar;
