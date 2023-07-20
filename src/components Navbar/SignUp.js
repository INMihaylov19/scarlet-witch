import React from 'react';
import { Link } from 'react-router-dom';

const SignUp = () => {
  return (
    <div>
      <h2>Sign Up</h2>
      {/* Sign Up form */}
      <Link to="/login">Already have an account? Login here.</Link>
    </div>
  );
};

export default SignUp;