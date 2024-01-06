import { FC, useEffect, useState } from "react"
import styles from './NavBar.module.scss'

import { LuLayoutDashboard } from "react-icons/lu";
import { HiOutlineCollection } from "react-icons/hi";
import { FaRegStar } from "react-icons/fa";
import { FiLogOut } from "react-icons/fi";
import { useAuth } from "../../hooks/useAuth";
import { $axios } from "../../api";
import { Link, useNavigate } from "react-router-dom";
import { LuSettings2 } from "react-icons/lu";


const NavBar:FC = () => {
    const navigate = useNavigate()
    const [userData, setUserData] = useState({})
    const {isAuth, authEmail, authUsername} = useAuth()

    useEffect(() => {
        getUserData()
    }, [authEmail, authUsername])


    const getUserData = () => {
        $axios(`/auth/users/${authUsername}`)
            .then(res => {
                console.log(res.data)
                setUserData(res.data.data)
            })
    }

    const SignOut = () => {
        localStorage.removeItem('authToken')
        localStorage.removeItem('authEmail')
        localStorage.removeItem('authUsername')

        navigate('/')
        window.location.reload()
    }

    return (
        <div className={styles.page__left}>

            <div className={styles.page__top}>
                <div className={styles.page__left__header}>
                    <img src={userData.imageLink || '/public/ImageNotFound.jpg'} alt="image" />
                    <div className={styles.page__left__header__desc}>
                        <Link to={`/profile/${authUsername}`}>{authUsername}</Link>
                        <span>{authEmail}</span>
                    </div>
                </div>

                <div className={styles.page__left__menu}>
                    <Link to='/dashboard'><LuLayoutDashboard />All Projects</Link>
                    <a><HiOutlineCollection /> Collections</a>
                    <Link to='/favorites'><FaRegStar /> Favorites</Link>
                    <Link to='/settings'><LuSettings2 /> Settings</Link>
                </div>
            </div>

            <div className={styles.page__footer}>
                <div className={styles.page__left__footer}>
                    <button onClick={SignOut}>Sign Out <FiLogOut /></button>
                </div>
            </div>
        </div>
    )
}

export default NavBar