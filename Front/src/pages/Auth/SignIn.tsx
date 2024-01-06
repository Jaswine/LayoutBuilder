import { FC, useEffect, useState } from "react"
import styles from "./Auth.module.scss"
import { Link, useNavigate } from "react-router-dom"
import { useAuth } from "../../hooks/useAuth"
import { $axios } from "../../api"
import { FaArrowRight } from "react-icons/fa6";
import Message from "../../components/Message/Message"


const SignIn:FC = () => {
    const navigate = useNavigate()
    const {setAuthEmail, authEmail, authUsername, setIsAuth, setAuthUsername, isAuth} = useAuth()
    const [errorMessage, setErrorMessage] = useState<string>('')

    const [email, setEmail] = useState<string>('')
    const [password, setPassword] = useState<string>('')

    useEffect(() => {
        document.title = 'Sign In'

        // isAuth && navigate('/dashboard')
    }, [])

    useEffect(() => {
        setTimeout(() => {
            setErrorMessage('')
        }, 5000)
    }, [errorMessage])

    const authorization = (e) => {
        e.preventDefault()

        $axios.post('/auth/sign-in', {
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
                    window.location.reload()
                } else {
                    setErrorMessage(res.data.message)
                }
            })
            .catch(err => {
                console.log(err)
                console.log(err.message)
            })
    }

    return (
    <div className={styles.page}>
        {errorMessage && <Message>{ errorMessage }</Message>}
        <form className={styles.form} method="post" onSubmit={authorization}>
            <h1>Sign In</h1>
            <p>Sign in to continue using the site!</p>

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

            <button className="btn">Continue <FaArrowRight /></button>

            <span>You don't have an account? <Link to='/sign-up' className="link">Sign Up</Link></span>

        </form>
    </div>
    )
}

export default SignIn