import { FC, useState } from "react";
import styles from './Intro.module.scss'
import { MdOutlineEmail } from "react-icons/md";
import { FaArrowRight } from "react-icons/fa6";
import { Link, useNavigate } from "react-router-dom";

const Intro:FC = () => {
    const [email, setEmail] = useState<string>('')
    const navigate = useNavigate()

    const goToSignUp = () => {
        localStorage.setItem('email', email)
        navigate('/sign-up')
    }

    return (
        <div className={styles.intro}>
            <div className={styles.intro__left}>
                <span className={styles.intro__left__tag}>LAYOUT BUILDER</span>
                <h1>Create designs with us!</h1>
                <p>Using our designer, you can create your own website and application layouts in a short time with minimal knowledge, and also speed up the time of writing styles in CSS</p>
                <div className={styles.intro__left__email}>
                    <MdOutlineEmail />
                    <input 
                        type="email"
                        value={email}
                        onChange={e => setEmail(e.target.value)}
                        placeholder="Enter your email address" />
                    <button onClick={goToSignUp} className="btn">Registration <FaArrowRight className='button__icon' /></button>
                </div>
            </div>
            <div className={styles.intro__right}>
                <span className={styles.intro__right__violet}></span>
                <span className={styles.intro__right__pink}></span>
                <img src="/public/constructor.png" alt="intro__image" />
            </div>
        </div>
    )
}

export default Intro
