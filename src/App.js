import React from "react"; 
import "./App.css";
import Header from "./components Header/Header";
import Navbar from "./components Navbar/Navbar";
import Signup from './components Navbar/SignUp';
import { BrowserRouter as Router, Route, Routes} from 'react-router-dom';


function App() {
  return (
    <Router>
    <div className="App">
      <Navbar />
      <Routes>
        <Route exact path="/" component={Home} />
        <Route path="/signup" component={Signup} />
      </Routes>
      <Header></Header>
    </div>
  </Router>
  );
}

const Home = () => {
  return <h2>Home Page</h2>;
};

export default App;