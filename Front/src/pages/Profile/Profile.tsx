import { FC, useEffect, useState } from "react";
import styles from './Profile.module.scss'
import { Link, useNavigate, useParams } from "react-router-dom";
import { $axios } from "../../api";
import NavBar from "../../components/NavBar/NavBar";
import { useAuth } from "../../hooks/useAuth";
import ProjectsList from "../../components/ProjectsList/ProjectsList";

interface PublicProject {
    id: number;
    data: string;
    title: string;
    updatedAt: string;
  }

interface PublicProjectsListProps {
    projects: PublicProject[];
    link_to: string;
    username: string;
}

const Profile:FC = () => {
    const { username } = useParams()
    const navigate = useNavigate()
    const {isAuth} = useAuth()
    const [profile, setProfile] = useState([])
    const [publicProjects, setPublicProjects] = useState<PublicProjectsListProps>([])

    useEffect(() => {
        document.title = `${username}`
        !isAuth && navigate('/sign-in')

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
                    <img src={profile.imageLink || '/public/ImageNotFound.jpg'} alt="image" />
                    <div className={styles.profile__info__desc}>
                        <h1>{profile.username}</h1>
                        <h2>{profile.email}</h2>
                        <p>{profile.about}</p>
                    </div>
                </div>
            </div>

            <ProjectsList projects={publicProjects} link_to="profile" username={profile.username} />

        </div>
        </div>
    )
}

export default Profile;