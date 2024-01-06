import { FC, useEffect, useState } from "react";
import styles from './Project.module.scss'
import NavBar from "../../components/NavBar/NavBar";
import { Link, useNavigate, useParams } from "react-router-dom";
import { $axios } from "../../api";
import { FaRegBookmark } from "react-icons/fa6";
import profileStyles from './../Profile/Profile.module.scss'
import { useAuth } from "../../hooks/useAuth";
import { IoCloseCircleOutline } from "react-icons/io5";
import Message from "../../components/Message/Message";
import ProjectsList from "../../components/ProjectsList/ProjectsList";
import Loading from "../../components/Loading/Loading";

const Project:FC = () => {
    const {username, id} = useParams()
    const [successfullyMessage, setSuccessfullyMessage] = useState('')
    const navigate = useNavigate()
    const {isAuth, authEmail, authUsername} = useAuth()
    const [project, setProject] = useState(null)
    const [profile, setProfile] = useState(null)
    const [publicProjects, setPublicProjects] = useState([])

    const [comments, setComments] = useState([])
    const [comment, setComment] = useState<string>('')

    useEffect(() => {
        !isAuth && navigate('/sign-in')
        
        setProfile(null)
        setProject(null)
        setPublicProjects([])

        getProjectData()
        getProfileData()
    }, [id, username])

    useEffect(() => {
        setTimeout(() => {
            setSuccessfullyMessage('')
        }, 5000)
    }, [successfullyMessage])    

    const getProjectData = () => {
        $axios(`/project/${id}`)
            .then(res => {
                setProject(res.data.data)
                setComments(res.data.data.comments) 
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

    const CreateNewComment = (e) => {
        e.preventDefault()
        
        $axios.post(`/project/${id}/comments`, {
            'text': comment
        })
            .then((res) => {
                getProjectData()
                setComment('')
                console.log(res.data)
            })
    }

    const deleteComment = (id) => {
        if (confirm('Are you sure you want to delete this comment?')) {
            $axios.delete(`/project/${id}/comments/${id}`)
            .then((res) => {
                console.log(res.data)
                getProjectData()
                setSuccessfullyMessage(res.data.message)
            })
        } 
    }

    return (
        <div className={styles.page}>
            <NavBar/>
            {successfullyMessage && <Message>{successfullyMessage}</Message>}
            {project  ?  (
                <div className={styles.page__right}>
                <h1>{project.title}</h1>
                <div className={styles.page__right__creator}>
                   <div className={styles.page__right__creator__left}>
                        <img src={project.user.imageLink || '/public/ImageNotFound.jpg'} alt="profile image" />
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
                    dangerouslySetInnerHTML={{ __html: project.data }}> 
                </div>

                <div className={styles.page__right__description}>
                    {project.description}
                </div>

                <div className={styles.page__right__creator__full}>
                    <div>
                        <span></span>
                        <img src={project.user.imageLink || '/public/ImageNotFound.jpg'} alt="profile image 2" />
                        <span></span>
                    </div>
                    <Link  to={`/profile/${username}`}>{username}</Link>
                    <p>{project.user.about}</p>
                </div>

                {/*  Other Projects */}
                <div className={styles.page__right__creator}>
                    <h3>More by <b>{username}</b></h3>
                    <Link to={`/profile/${username}`}>View profile</Link>
                </div>

                <div className={styles.page__right__creator__works}>
                    <ProjectsList projects={publicProjects} link_to="profile" username={project.user.username}  />
                </div>

                {/* Comments */}
                {project.allowComments? (
                <>
                    <div className={styles.page__right__creator}>
                        <h3>Comments</h3>
                    </div>

                    <form className={styles.page__right__create__comment} onSubmit={CreateNewComment}>
                        <input 
                            type="text"
                            placeholder="Enter your comment..."
                            value={comment}
                            onChange={e => setComment(e.target.value)} />
                        <button>Save</button>
                    </form>

                    <div className={styles.page__comments}>
                        {comments.length > 0 ? (
                            <div className={styles.page__comments__all}>
                                {comments.map((comment, key) => 
                                    <div className={styles.page__comment} key={key}>
                                        <div className={styles.page__comment__header}>
                                            <Link to={`/profile/${comment.user.username}`}>{comment.user.username}</Link>
                                            <div >
                                                <span>{comment.createdAt.slice(0, 10)}</span>
                                                {authUsername == comment.user.username && (<button onClick={() => deleteComment(comment.id)}><IoCloseCircleOutline /></button>)}
                                            </div>                                        
                                        </div>
                                        <div className={styles.page__comment__body}>
                                            {comment.text}
                                        </div>
                                    </div>    
                                )}
                            </div>
                        ): (
                            <h2>Comments not found</h2>
                        )} 
                    </div> 
                </>
                ): (<div className={styles.comments_not_allowed}>Comments not allowed</div>)}
            </div> 
            ) : <div className={styles.loading}><Loading/></div>}
        </div>
    )
}

export default Project