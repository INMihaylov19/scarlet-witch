import React from "react";
import "../styles/App.css";

const Home = () => {
  return (
    <div className="navbarClass">
      <nav className="navbar bg-white">
        <div className="container">
          <div className="navbar-content">
            <div className="brand-and-toggler">
              <a href="#" className="navbar-brand">
                <img
                  src="assets/images/Resume.png"
                  alt=""
                  className="navbar-brand-icon"
                />
                <span className="navbar-brand-text">
                  build <span>resume.</span>
                </span>
              </a>
            </div>
          </div>
        </div>
      </nav>

      <header className="header bg-bright" id="header">
        <div className="container">
          <div className="header-content text-center">
            <h6 className="text-uppercase text-blue-dark fs-14 fw-6 ls-1">
              online CV/resume builder
            </h6>
            <h1 className="lg-title">
              Only 2% of resumes make it past the first round. Be in the top 2%
            </h1>
            <p className="text-dark fs-18">
              Use professional field-tested resume templates that follow the
              exact 'resume rules' employers look for. Easy to use and done
              within minutes - try now for free!
            </p>
            <a href="http://localhost:3000/Login" className="btn btn-primary text-uppercase">Create an account</a>
            <a href = "http://localhost:3000/Create" class = "btn btn-secondary text-uppercase">get started</a>
          </div>
        </div>
      </header>
    </div>
  );
};

export default Home;
