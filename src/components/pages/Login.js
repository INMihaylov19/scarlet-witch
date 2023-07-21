import React, { useState, useEffect } from "react";
import loginstyle from "../styles/Login.module.css";
import axios from "axios";
import { useNavigate, NavLink } from "react-router-dom";
const Login = ({ setUserState }) => {
  const navigate = useNavigate();

  const [user, setUser] = useState({
    Username: "",
    password: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({
      ...user,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("https://localhost:7119/api/Login", user);
      if (response.status === 200) {
        const token = response.data;
        // Store the token in local storage or use it as needed
        console.log("Token:", token);
        alert("Login successful!");
        // Redirect to the dashboard or any other protected page
      }
    } catch (error) {
      if (error.response && error.response.status === 401) {
        alert("Invalid username or password.");
      } else {
        alert("An error occurred during login.");
      }
    }
  };

  return (
    <div className={loginstyle.login}>
      <form onSubmit = {handleSubmit}>
        <h1>Login</h1>
        <input
          type="text"
          name="username"
          placeholder="Username"
          value={user.username}
          onChange={handleChange}
        />
        <input
          type="password"
          name="password"
          placeholder="Password"
          value={user.password}
          onChange={handleChange}
        />
        <button className={loginstyle.button_common} type = "submit">
          Login
        </button>
      </form>
      <NavLink to="http://localhost:3000/Register">Not yet registered? Register Now</NavLink>
    </div>
  );
};
export default Login;