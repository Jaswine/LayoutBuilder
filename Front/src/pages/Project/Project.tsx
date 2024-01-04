import { FC, useEffect, useState } from "react";
import styles from './Project.module.scss'
import NavBar from "../../components/NavBar/NavBar";
import { Link, useParams } from "react-router-dom";
import { $axios } from "../../api";
import { FaRegBookmark } from "react-icons/fa6";
import profileStyles from './../Profile/Profile.module.scss'


const Project:FC = () => {
    const {username, id} = useParams()
    const [project, setProject] = useState(null)
    const [profile, setProfile] = useState(null)
    const [publicProjects, setPublicProjects] = useState([])

    useEffect(() => {
        setProfile(null)
        setProject(null)
        setPublicProjects([])

        getProjectData()
        getProfileData()
    }, [id, username])

    const getProjectData = () => {
        $axios(`/project/${id}`)
            .then(res => {
                setProject(res.data.data)
                console.log(res.data.data)
            })
    }

    const getProfileData = () => {
        $axios(`/auth/users/${username}/public`)
            .then((res) => {
                console.log(res.data)
                setProfile(res.data.data)
                setPublicProjects(res.data.data.projects.slice(0, 3))
            })
    }

    return (
        <div className={styles.page}>
            <NavBar/>
            {project  ?  (
                <div className={styles.page__right}>
                <h1>{project.title}</h1>
                <div className={styles.page__right__creator}>
                   <div className={styles.page__right__creator__left}>
                        <img src="https://images.unsplash.com/photo-1704125567682-c735c82e9165?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyOHx8fGVufDB8fHx8fA%3D%3D" alt="profile image" />
                        <div className="">
                            <Link to={`/profile/${username}`} >{username}</Link>
                            <span>{project.createdAt.slice(0, 10)}</span>
                        </div>
                   </div>
                   <div className={styles.page__right__creator__right}>
                        <button><FaRegBookmark /></button>
                   </div>
                </div>
                <div 
                    className={styles.page__right__maket}
                    dangerouslySetInnerHTML={{ __html: project.data }}
                    >
                    
                </div>
                <div className={styles.page__right__creator}>
                    <h3>More by <b>{username}</b></h3>
                    <Link to={`/profile/{username}`}>View profile</Link>
                </div>
                <div className={profileStyles.profile__projects}>
                    {publicProjects ? (
                        <div className={profileStyles.profile__projects__all}>
                            {publicProjects.map((p, index) => 
                                <Link
                                    to={`/profile/${username}/projects/${p.id}`} 
                                    className={profileStyles.project} 
                                    key={index}>
                                    <iframe src="/dashboard" 
                                            loading="lazy"
                                            scrolling="no"></iframe>
                                    <Link to={`/profile/${username}/projects/${p.id}`}>{p.title}</Link>
                                    <span>{p.updatedAt.slice(0, 10)}</span>
                            </Link>
                            )}
                        </div>
                    ): (<div>Loading...</div>)}
                </div>

                <div className={styles.page__right__creator}>
                    <h3>Comments</h3>
                </div>

                <div className={styles.page__comments}>
                    
                </div>
            </div>
            ) : <h2>Loading...</h2>}
        </div>
    )
}

export default Project