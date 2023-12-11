import { useState } from 'react'
import styles from './../SignIn/SignIn.module.scss'
import Button from '../../components/UI/Button/Button'


const SignUp = () => {
    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const sign_in = async (e) => {
        e.preventDefault()

        console.log(email, password)
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
                <Button onClick={sign_in}>Continue</Button>

                    <p>Don't have an account? Create a new account</p>
               </div>
            </form>
        </div>
    )
}

export default SignUp