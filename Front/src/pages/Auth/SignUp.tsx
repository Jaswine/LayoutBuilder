import { FC, useEffect, useState } from "react"
import styles from "./Auth.module.scss"
import { Link, useNavigate } from "react-router-dom"
import { useAuth } from "../../hooks/useAuth"
import { $axios } from "../../api"
import Message from "../../components/Message/Message"


const SignUp:FC = () => {
    const navigate = useNavigate()
    const {setAuthUsername, setAuthEmail, setIsAuth, isAuth} = useAuth()
    const [errorMessage, setErrorMessage] = useState<string>('')

    const [username, setUsername] = useState<string>('')
    const [email, setEmail] = useState<string>('')
    const [password, setPassword] = useState<string>('')

    useEffect(() => {
        document.title = 'Sign Up'

        const localStorageEmail = localStorage.getItem('email')
        localStorageEmail && setEmail(localStorageEmail)

        isAuth && navigate('/dashboard')
    }, [])

    useEffect(() => {
        setTimeout(() => {
            setErrorMessage('')
        }, 5000)
    }, [errorMessage])

    const authorization = (e) => {
        e.preventDefault()

        $axios.post('/auth/sign-up', {
            'username': username,
            'email': email,
            'password': password
        })
            .then(res => {
                console.log(res.data)

                if (res.data.success) {
                    setIsAuth(true)
                    localStorage.setItem('authToken', res.data.token)

                    setAuthEmail(res.data.data.email)
                    localStorage.setItem('authEmail', res.data.data.email)

                    setAuthUsername(res.data.data.username)
                    localStorage.setItem('authUsername', res.data.data.username)

                    navigate('/dashboard')
                } else {
                    setErrorMessage(res.data.message)
                }
            })
            .catch(err => {
                console.log(err)
            })
    }

    return (
    <div className={styles.page}>
        {errorMessage && <Message>{ errorMessage }</Message>}
        <form className={styles.form} method="post" onSubmit={authorization}>
            <h1>Sign Up</h1>
            <p>Register to continue using the site!</p>

            <div className={styles.form__field}>
                <label>Username:</label>
                <input 
                    type="text" 
                    onChange={e => setUsername(e.target.value)}
                    value={username} 
                    required />
            </div>

            <div className={styles.form__field}>
                <label>Email:</label>
                <input 
                    type="email" 
                    onChange={e => setEmail(e.target.value)}
                    value={email} 
                    required />
            </div>

            <div className={styles.form__field}>
                <label>Password:</label>
                <input 
                    type="password" 
                    onChange={e => setPassword(e.target.value)}
                    value={password} 
                    required />
            </div>

            <button className="btn">Continue</button>

            <span>Account has been created? <Link to='/sign-in' className="link">Sign In</Link></span>

        </form>
    </div>
    )
}

export default SignUp