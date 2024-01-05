import { FC, useEffect, useState } from "react";
import styles from './Profile.module.scss'
import { Link, useNavigate, useParams } from "react-router-dom";
import { $axios } from "../../api";
import NavBar from "../../components/NavBar/NavBar";
import { useAuth } from "../../hooks/useAuth";

const Profile:FC = () => {
    const { username } = useParams()
    const navigate = useNavigate()
    const {isAuth} = useAuth()
    const [profile, setProfile] = useState([])
    const [publicProjects, setPublicProjects] = useState([])

    useEffect(() => {
        document.title = `${username}`

        if (!isAuth) {
            navigate('/sign-in')
        }

        getProfileData()
    }, [username])

    const getProfileData = () => {
        $axios(`/auth/users/${username}/public`)
            .then((res) => {
                console.log(res.data)
                setProfile(res.data.data)
                setPublicProjects(res.data.data.projects)
            })
    }

    return (
        <div className={styles.page}>
            <NavBar/>
            <div className={styles.profile}>
            <div className={styles.profile__data}>
                <div className={styles.profile__info}>
                    <img src="https://images.unsplash.com/photo-1704125567682-c735c82e9165?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyOHx8fGVufDB8fHx8fA%3D%3D" alt="image" />
                    <div className={styles.profile__info__desc}>
                        <h1>{profile.username}</h1>
                        <h2>{profile.email}</h2>
                    </div>
                </div>
                <p>{profile.about}</p>
            </div>
            <div className={styles.profile__projects}>
                {publicProjects ? (
                    <div className={styles.profile__projects__all}>
                        {publicProjects.map((project, index) => 
                            <Link
                                 to={`/profile/${username}/projects/${project.id}`} 
                                 className={styles.project} 
                                 key={index}>
                                <iframe src="/dashboard" 
                                        loading="lazy"
                                        scrolling="no"></iframe>
                                <Link to={`/profile/${username}/projects/${project.id}`}>{project.title}</Link>
                                <span>{project.updatedAt.slice(0, 10)}</span>
                         </Link>
                        )}
                    </div>
                ): (<div>Loading...</div>)}
            </div>
        </div>
        </div>
    )
}

export default Profile;