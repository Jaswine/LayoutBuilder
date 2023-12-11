import {useEffect, useState} from 'react'
import styles from './Index.module.scss'

const Index = () => {
    const [projects, setProjects] = useState([])
    
    useEffect(() => {
        getProjects()
    }, [])

    const getProjects = async () => {
        const response = await fetch('http://localhost:5179/api/project/list')
        const data = await response.json()
        setProjects(data.data)
        console.log(data)
    }

    return (
        <div className={styles.page}>
            <div className="page__projects">
                {projects.map(project => 
                    <div className={styles.page__project} key={project.id}>
                        <a href="" className={styles.page__project__link}>{project.title}</a>
                    </div>    
                )}
            </div>
        </div>
    )
}

export default Index