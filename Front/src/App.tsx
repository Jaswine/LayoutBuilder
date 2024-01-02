import { Route, Routes } from "react-router-dom"
import SignUp from "./pages/Auth/SignUp"
import SignIn from "./pages/Auth/SignIn"
import Dashboard from "./pages/Dashboard/Dashboard"
import Index from "./pages/Index/Index"


function App() {
  return (
    <Routes>
      <Route path="/" element={<Index/>} />
      <Route path="/sign-up" element={<SignUp/>} />
      <Route path="/sign-in" element={<SignIn/>} />

      <Route path="/dashboard" element={<Dashboard/>} />
    </Routes>
  )
}

export default App
