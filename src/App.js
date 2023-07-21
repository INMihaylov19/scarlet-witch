import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from '../src/components/pages/Home'
import Create from '../src/components/pages/Create/Create'
import Login from '../src/components/pages/Login'
import Register from '../src/components/pages/Register'

function App() {
  return (
<div>
  <BrowserRouter>
    <Routes>
       <Route index element={<Home />} /> 
       <Route path="/home" element={<Home />} /> 
       <Route path="/login" element={<Login />} />
       <Route path="/register" element={<Register />} /> 
       <Route path="/create" element={<Create />} /> 
    </Routes>
  </BrowserRouter>
</div>
  );
}

export default App;