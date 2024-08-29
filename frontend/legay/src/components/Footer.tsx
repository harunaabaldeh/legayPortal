import React from "react";

const Footer: React.FC = () => {
  return (
    <footer className="bg-white py-8 mt-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex flex-wrap justify-between text-gray-600 text-sm">
          <div className="flex space-x-4">
            <a href="#" className="hover:underline">
              Hiring Lab
            </a>
            <a href="#" className="hover:underline">
              Career Advice
            </a>
            <a href="#" className="hover:underline">
              Browse Jobs
            </a>
            <a href="#" className="hover:underline">
              Browse Companies
            </a>
          </div>
          <div className="flex space-x-4">
            <a href="#" className="hover:underline">
              © 2024 Indeed
            </a>
            <a href="#" className="hover:underline">
              Your Privacy Choices
            </a>
            <a href="#" className="hover:underline">
              Accessibility at Indeed
            </a>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
