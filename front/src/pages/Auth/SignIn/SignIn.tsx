import {useState, FC} from 'react'
import styles from './SignIn.module.css'

const SignIn:FC = () => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    return (
        <div className={styles.page}>
            <div className={styles.page__left}>
                <div className={styles.page__left__text}></div>
                <img src="/sign_in.jpg" alt="sign_in" />
            </div>
            <div className={styles.page__right}>
                <form action="">
                    <h2>Hi, Welcome back!</h2>
                    <p>Enter your details to access your account</p>
                    <div className={styles.form__component}>
                        <label htmlFor="">Email:</label>
                        <input type="email" placeholder='Enter your email...' />
                    </div>
                    <div className={styles.form__component}>
                        <label htmlFor="">Password:</label>
                        <input type="password" placeholder='Enter your password...' />
                    </div>
                    <button className={styles.btn}>Sign In</button>
                </form>
            </div>
        </div>
    )
}

export default SignIn