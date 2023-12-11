import { useState } from 'react'
import styles from './SignIn.module.scss'
import Button from '../../components/UI/Button/Button'
import { Link, useNavigate } from 'react-router-dom'
import axios from 'axios'


const SignIn = () => {
    const navigate = useNavigate('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState('')

    const sign_in = async (e) => {
        e.preventDefault()

        console.log(email, password)

        axios.post(`http://localhost:5179/api/auth/sign-in`, {
            email: email, 
            password: password 
        }).then(res => {
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
                <h2>Sign In</h2>
                <p>Please sign-in to your account and start the adventure</p>

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
                <Button onClick={sign_in}>Continue</Button>

                    <p>Don't have an account? <Link to='/auth/sign-up' className='link'>Create a new account</Link></p>
               </div>
            </form>
        </div>
    )
}

export default SignIn