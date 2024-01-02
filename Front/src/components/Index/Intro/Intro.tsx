import { FC } from "react";
import styles from './Intro.module.scss'
import { MdOutlineEmail } from "react-icons/md";
import { FaArrowRight } from "react-icons/fa6";

const Intro:FC = () => {
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
                        placeholder="Enter your email address" />
                    <button className="btn">Registration <FaArrowRight className='button__icon' /></button>
                </div>
            </div>
            <div className={styles.intro__right}>
                <span className={styles.intro__right__violet}></span>
                <span className={styles.intro__right__pink}></span>
                <img src="https://images.unsplash.com/photo-1522199755839-a2bacb67c546?q=80&w=2672&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="intro__image" />
            </div>
        </div>
    )
}

export default Intro
