import { Route, Routes } from "react-router-dom"
import SignUp from "./pages/Auth/SignUp"
import SignIn from "./pages/Auth/SignIn"
import Dashboard from "./pages/Dashboard/Dashboard"
import Index from "./pages/Index/Index"
import Constructor from "./pages/Constructor/Constructor"
import Profile from "./pages/Profile/Profile"
import Project from "./pages/Project/Project"
import Settings from "./pages/Settings/Settings"
import NotFound from "./pages/NotFound/NotFound"
import { useAuth } from "./hooks/useAuth"


function App() {
  const {isAuth} = useAuth()

  return (
    <Routes>
      <Route path="/" element={<Index/>} />
      <Route path="/sign-up" element={<SignUp/>} />
      <Route path="/sign-in" element={<SignIn/>} />

      {isAuth && (
        <>
          <Route path="/dashboard" element={<Dashboard/>} />
          <Route path="/dashboard/:id" element={<Constructor/>} />

          <Route path="/profile/:username" element={<Profile/>} />
          <Route path="/settings" element={<Settings/>} />

          <Route path="/profile/:username/projects/:id" element={<Project/>} />
        </>
      )}

      <Route path="*" element={<NotFound/>} />
      
    </Routes>
  )
}

export default App
