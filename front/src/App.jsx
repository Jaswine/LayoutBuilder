import {Routes, Route} from 'react-router-dom'
import SignIn from './pages/SignIn/SignIn'
import SignUp from './pages/SignUp/SignUp'
import SignOut from './pages/SignOut/SignOut'

function App() {
  return (
    <Routes>

      <Route path="/auth/sign-in" element={<SignIn />} />
      <Route path="/auth/sign-up" element={<SignUp />} />
      <Route path="/auth/sign-out" element={<SignOut />} />

    </Routes>
  )
}

export default App
