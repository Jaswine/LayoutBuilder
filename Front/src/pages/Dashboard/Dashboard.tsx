import { FC, useEffect, useState } from "react";
import { useAuth } from "../../hooks/useAuth";
import { Link, useNavigate } from "react-router-dom";
import styles from './Dashboard.module.scss'
import { $axios } from "../../api";
import NavBar from "../../components/NavBar/NavBar";
import ProjectsList from "../../components/ProjectsList/ProjectsList";
import Loading from "../../components/Loading/Loading";

interface Project {
    id: number;
    data: string;
    title: string;
    updatedAt: string;
    createdAt: string;
  }


interface ProjectsListProps {
    projects: Project[];
}

const Dashboard:FC = () => {
    const navigate = useNavigate()
    const {isAuth, authEmail, authUsername} = useAuth()

    const [projectsData, setProjectsData] = useState<ProjectsListProps>([])

    useEffect(() => {
        document.title = 'Dashboard'
        // !isAuth && navigate('/sign-in')

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
                
                <div className={styles.pre__page__right__projects}>
                    <ProjectsList projects={projectsData} link_to='dashboard' username={''}  />
                </div>

            </div>

        </div>
    )
}

export default Dashboard
