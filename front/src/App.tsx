import { useState } from 'react'
import { Routes, Route } from 'react-router-dom'

import Home from './pages/Home/Home'
import SignIn from './pages/Auth/SignIn/SignIn'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/sign-in" element={<SignIn />} />
      </Routes>
    </div>
  )
}

export default App
