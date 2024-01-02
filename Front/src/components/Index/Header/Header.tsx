import { FC } from "react";
import styles from './Header.module.scss'
import { Link } from "react-router-dom";
import { FaRegUserCircle } from "react-icons/fa";

const Header:FC = () => {
    return (
        <div className={styles.header}>
            <div className={styles.header__left}>
                <Link to='/' >Home</Link>
                <Link to='/' >About</Link>
                <Link to='/community' >Community</Link>
                <Link to='/documentation' >Documentation</Link>
                <Link to='/' >Contact</Link>
            </div>
            <div className={styles.header__right}>
                <Link to='/sign-in' >
                    <FaRegUserCircle />
                </Link>
            </div>
        </div>
    )
}

export default Header
