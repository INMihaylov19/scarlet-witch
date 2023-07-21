import React, { useEffect, useState } from "react";
import registerstyle from "../styles/Register.module.css";
import axios from "axios";

import { useNavigate, NavLink } from "react-router-dom";
const Register = () => {
  const navigate = useNavigate();

  const [formErrors, setFormErrors] = useState({});
  const [isSubmit, setIsSubmit] = useState(false);
  const [user, setUser] = useState({
    username: "",
    password: "",
    email: "",
    firstName: "",
    lastName: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({
      ...user,
      [name]: value,
    });
  };

  
  const signupHandler = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("https://localhost:7119/api/Register", user);
      if (response.status === 200) {
        alert("Registration successful!");
        // Redirect to login page or do any other necessary actions
      }
    } catch (error) {
      if (error.response && error.response.status === 409) {
        alert("Username is already taken.");
      } else {
        alert("An error occurred during registration.");
      }
    }
  };

  useEffect(() => {
    if (Object.keys(formErrors).length === 0 && isSubmit) {
      console.log(user);
      axios.post("http://localhost:3000/signup/", user).then((res) => {
        alert(res.data.message);
        navigate("/login", { replace: true });
      });
    }
  }, [formErrors]);
  return (
    <div className="registerMain">
      <div className={registerstyle.register}>
        <form onSubmit = {signupHandler}>
          <h1>Create your account</h1>
          <input
          type="text"
          name="username"
          placeholder="Username"
          value={user.username}
          onChange={handleChange}
          />
          <p className={registerstyle.error}>{formErrors.fname}</p>
          <input
          type="password"
          name="password"
          placeholder="Password"
          value={user.password}
          onChange={handleChange}
          />
          <p className={registerstyle.error}>{formErrors.lname}</p>
          <input
          type="email"
          name="email"
          placeholder="Email"
          value={user.email}
          onChange={handleChange}
          />
          <p className={registerstyle.error}>{formErrors.Username}</p>
          <input
          name="firstName"
          placeholder="First Name"
          value={user.firstName}
          onChange={handleChange}
          />
          <p className={registerstyle.error}>{formErrors.password}</p>
          <input
          type="text"
          name="lastName"
          placeholder="Last Name"
          value={user.lastName}
          onChange={handleChange}
          />
          <p className={registerstyle.error}>{formErrors.cpassword}</p>
          <button className={registerstyle.button_common} type="submit">
            Register
          </button>
        </form>
        <NavLink to="http://localhost:3000/Login">Already registered? Login</NavLink>
      </div>
    </div>
  );
};
export default Register;
