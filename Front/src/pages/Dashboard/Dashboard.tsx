import { FC, useEffect, useState } from "react";
import { useAuth } from "../../hooks/useAuth";
import { Link, useNavigate } from "react-router-dom";
import styles from './Dashboard.module.scss'
import { $axios } from "../../api";
import { TbLogout } from "react-icons/tb";
import NavBar from "../../components/NavBar/NavBar";


const Dashboard:FC = () => {
    const navigate = useNavigate()
    const {isAuth, authEmail, authUsername} = useAuth()

    const [projectsData, setProjectsData] = useState({})

    useEffect(() => {
        document.title = 'Dashboard'

        if (!isAuth) {
            navigate('/sign-in')
        }
    }, [isAuth])

    useEffect(() => {
        getUserData()
    }, [authEmail, authUsername])

    const getUserData = () => {
        $axios(`/auth/users/${authUsername}`)
            .then(res => {
                console.log(res.data)
                setProjectsData(res.data.data.projects)
            })
    }

    const newDesignFile = () => {
        $axios.post('/project', {
            'title': "Untitled"
        })
            .then(res => {
                console.log(res.data)
                getUserData()
                navigate(`/dashboard/${res.data.data.id}`)
            })
    }


    return (
        <div className={styles.page}>
            <NavBar/>
            <div className={styles.page__right}>

                <div className={styles.page__right__header}>
                    <h2>Recent projects</h2>
                    <button onClick={newDesignFile} className="btn">
                        New design file +
                    </button>
                </div>

                <div className={styles.page__right__filters}>
                    <div className={styles.page__right__filters__left}>
                        <span>All</span>
                        <span>Public</span>
                    </div>
                    <div className={styles.page__right__filters__right}>
                        <select name="" id="">
                            <option value="">Newest first</option>
                        </select>
                    </div>
                </div>

                <div className={styles.page__right__projects}>
                    {projectsData.length > 0
                    ?  ( <div className={styles.page__projects}>
                            {projectsData.map((project, index)=> 
                                <Link to={`/dashboard/${project.id}`} className={styles.project} key={index}>
                                    <iframe src="/dashboard" 
                                            loading="lazy"
                                            scrolling="no"></iframe>
                                    <Link to={`/dashboard/${project.id}`}>{project.title}</Link>
                                    <span>{project.updatedAt.slice(0, 10)}</span>
                                </Link>
                            )}
                        </div>)
                    :(<h2>Loading</h2>)}
                </div>

            </div>

        </div>
    )
}

export default Dashboard
