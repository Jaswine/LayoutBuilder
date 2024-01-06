import { FC } from "react"
import styles from './ProjectsList.module.scss'
import { Link } from "react-router-dom"
import Loading from "../Loading/Loading";

interface Project {
    id: number;
    data: string;
    title: string;
    updatedAt: string;
  }

interface ProjectsListProps {
    projects: Project[];
    link_to: string;
    username: string;
}

const ProjectsList:FC<ProjectsListProps> = ({projects , link_to, username}) => {
    return (
        <div className={styles.page__right__projects}>
            {projects.length > 0 ?
                (<div className={styles.page__projects}>
                    {projects.map((project, index) => 
                        <Link 
                            to={`/${link_to}${link_to == 'dashboard' ? '/' : `/${username}/projects/`}${project.id}`} 
                            className={styles.project} 
                            key={index}>
                            <div className={styles.project__iframe}>
                                <div
                                    className={styles.project__maket}
                                    dangerouslySetInnerHTML={{ __html: project.data }}
                                ></div>
                            </div>
                            <Link to={`/${link_to}${link_to == 'dashboard' ? '/' : `/${username}/projects/`}${project.id}`}>{project.title}</Link>
                            <span>{project.updatedAt.slice(0, 10)}</span>
                        </Link>
                    )}
                </div>)
                : (<div className={styles.page__right__loading}>
                    <Loading/>
                </div>)}
        </div>
    );
}

export default ProjectsList