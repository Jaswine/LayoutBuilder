import { FC, useEffect, useState } from "react"
import styles from './Settings.module.scss'
import NavBar from "../../components/NavBar/NavBar"
import { LuSettings2 } from "react-icons/lu";
import { Link, useNavigate } from "react-router-dom";
import { $axios } from "../../api";
import { useAuth } from "../../hooks/useAuth";
import Message from "../../components/Message/Message";

const Settings:FC = () => {
  const navigate = useNavigate()
  const {isAuth, authEmail, authUsername} = useAuth()
  const [successfullyMessage, setSuccessfullyMessage] = useState('')
  const [settingsForm, setSettingsForm] = useState({
    'username': authUsername,
    'email': authEmail,
    'imageLink': '',
    'about': '',
  })

  useEffect(() => {
    document.title = 'Settings'
    !isAuth && navigate('/sign-in')

    getUserInformation()
  }, [isAuth])

  useEffect(() => {
    setTimeout(() => {
        setSuccessfullyMessage('')
    }, 5000)
}, [successfullyMessage])

  const getUserInformation = () => {
    $axios(`/auth/users/${authUsername}`)
      .then(res => {
        console.log(res.data)
        setSettingsForm({'username': res.data.data.username, 
                                    'email': res.data.data.email, 
                                    'imageLink': res.data.data.imageLink,
                                    'about': res.data.data.about})
      })
  }

  const saveSettings = (e) => {
    e.preventDefault()

    $axios.put(`/auth/users/${authUsername}`, settingsForm)
      .then(res => {
        console.log(res.data)
        setSuccessfullyMessage(res.data.message) 
      })
  }

  return (
    <div className={styles.page}>
        {successfullyMessage && <Message>{successfullyMessage}</Message>}
        <NavBar/>
        {settingsForm? (
        <div className={styles.page__right}>
          
          <h1>Settings 📝</h1>

          <form method="POST" onSubmit={saveSettings}>

            <div>
              <label htmlFor="">Username:</label>
              <input 
                type="text"
                value={settingsForm.username}
                onChange={e => setSettingsForm({...settingsForm, username: e.target.value})}
                placeholder="Enter your username"
              />
            </div>

            <div>
              <label htmlFor="">Email:</label>
              <input 
                type="email"
                value={settingsForm.email}
                onChange={e => setSettingsForm({...settingsForm, email: e.target.value})}
                placeholder="Enter your email"
              />
            </div>

            <div>
              <label htmlFor="">Image Link:</label>
              <input 
                type="text"
                value={settingsForm.imageLink}
                onChange={e => setSettingsForm({...settingsForm, imageLink: e.target.value})}
                placeholder="Enter your image link"
              />
            </div>

            <div>
              <label htmlFor="">About:</label>
              <textarea 
                value={settingsForm.about}
                onChange={e => setSettingsForm({...settingsForm, about: e.target.value})}
                placeholder="Talk about you"
              ></textarea>
            </div>

            <div className={styles.buttons}>
              <Link to={'/dashboard'} >Cancel</Link>
              <button>Save</button>
            </div>
          </form>

        </div>
        ): (<h2>Loading...</h2>)}
    </div>
  )
}

export default Settings