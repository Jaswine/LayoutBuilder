import { Route, Routes } from "react-router-dom"
import SignUp from "./pages/Auth/SignUp"
import SignIn from "./pages/Auth/SignIn"
import Dashboard from "./pages/Dashboard/Dashboard"
import Index from "./pages/Index/Index"
import Constructor from "./pages/Constructor/Constructor"
import Profile from "./pages/Profile/Profile"
import Project from "./pages/Project/Project"


function App() {
  return (
    <Routes>
      <Route path="/" element={<Index/>} />
      <Route path="/sign-up" element={<SignUp/>} />
      <Route path="/sign-in" element={<SignIn/>} />

      <Route path="/dashboard" element={<Dashboard/>} />
      <Route path="/dashboard/:id" element={<Constructor/>} />

      <Route path="/profile/:username" element={<Profile/>} />
      <Route path="/profile/:username/projects/:id" element={<Project/>} />

      
    </Routes>
  )
}

export default App
