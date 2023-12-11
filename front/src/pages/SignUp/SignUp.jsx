import { useState } from 'react'
import styles from './../SignIn/SignIn.module.scss'
import Button from '../../components/UI/Button/Button'
import { Link, useNavigate } from 'react-router-dom'
import axios from 'axios'


const SignUp = () => {
    const navigate = useNavigate('')
    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState('')

    const sign_up = async (e) => {
        e.preventDefault()

        axios.post(`http://localhost:5179/api/auth/sign-up`, {
            username: username, 
            email: email, 
            password: password 
        }).then(res => {
            console.log(res)
            console.log(res.data.message)
        //   navigate('/')
        }) 
        .catch(err => {
          console.log(err)
          setError(err.response.data.message)
        })
    }

    return (
        <div className={styles.pre__form}>
            <form method='POST' className={styles.form}>
                <h2>Sign Up</h2>
                <p>Make your app management easy and fun!</p>

                <div className={styles.form__component}>
                    <label htmlFor="">Username</label>
                    <input 
                        type="text"
                        onChange={e => setUsername(e.target.value)}
                        value={username}
                        placeholder='Enter your username...'
                        required
                    />
                </div>

                <div className={styles.form__component}>
                    <label htmlFor="">Email</label>
                    <input 
                        type="text"
                        onChange={e => setEmail(e.target.value)}
                        value={email}
                        placeholder='Enter your email...'
                        required
                    />
                </div>

                <div className={styles.form__component}>
                    <label htmlFor="">Password</label>
                    <input 
                        type="password"
                        onChange={e => setPassword(e.target.value)}
                        value={password}
                        placeholder='Enter your password...'
                        required
                    />
                </div>

               <div className={styles.form__bottom}>
                <Button onClick={sign_up}>Continue</Button>

                    <p>You have an account? <Link to='/auth/sign-in' className='link'>Sign In</Link></p>
               </div>
            </form>
        </div>
    )
}

export default SignUp