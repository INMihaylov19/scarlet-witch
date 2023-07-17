import React from 'react';
import Button from './Button';
import Home from './Home';
import SignUp from './SignUp';

const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="navbar-title">Welcome to CV Resume Builder Website</div>
      <div className="navbar-buttons"></div>
      <Home />
      <div className="buttons">
        <SignUp />
      </div>
    </nav>
  );
};

export default Navbar;