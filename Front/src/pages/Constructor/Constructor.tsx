import { FC, useEffect, useState } from "react";
import styles from './Constructor.module.scss'
import { Link, useNavigate, useParams } from "react-router-dom";
import { $axios } from "../../api";

import { GrAppsRounded } from "react-icons/gr";
import { LuLayoutList } from "react-icons/lu";
import { AiOutlineAppstoreAdd } from "react-icons/ai";
import { RiShareForwardLine } from "react-icons/ri";
import { FaRegTrashAlt } from "react-icons/fa";
import MenuElements from "./MenuElements";
import { IoCloseCircleOutline } from "react-icons/io5";
import { useAuth } from "../../hooks/useAuth";

const Constructor:FC = () => {
    const {id} = useParams()
    const {authUsername, isAuth} = useAuth()
    const navigate = useNavigate()
    const [project, setProject] = useState({})

    const [projectTitle, setProjectTitle] = useState<string>('')
    const [projectData, setProjectData] = useState('')
    const [projectOtherData, setProjectOtherData] = useState({
        'description': '',
        'allowComments': false,
    })

    const [mainMenu, setMainMenu] = useState<string>('ElementsMenu')
    const [mainMenuPlace, setMainMenuPlace] = useState([])

    const [projectPrivacyWindow, setProjectPrivacyWindow] = useState<boolean>(false)

    useEffect(() => {
        document.title = 'Constructor'
        !isAuth && navigate('/sign-in')

        getProjectData()
    }, [id])

    useEffect(() => {
        if (mainMenu == 'ElementsMenu') {
            MenuElements.map((element) => {
                console.log(element)
            })
        }
    }, [id, MenuElements])
    

    const renderTemplate = (data) => {
        setProjectData(data)
        $axios.put(`/project/${id}/data`, {
            "data": data,
        })
            .then(res => {
                console.log(res.data)
            })
            .catch(err => {
                console.error(err)
            })
    }

   const getProjectData = () => {
        $axios(`/project/dashboard/${id}`)
        .then(res => {
            console.log(res.data)
            setProject(res.data.data)
            setProjectTitle(res.data.data.title)

            if (res.data.data.data) {
                setProjectData(res.data.data.data)
            } else {
                renderTemplate(`<h1 style="font-size: 32px; font-weight: bold;">Hello World!🖐️</h1>`)
            }

            setProjectOtherData({
                'description': res.data.data.description,
                'allowComments': res.data.data.allowComments,
            })
        })
   } 

    const changeProjectTitle = (e) => {
        setProjectTitle(e.target.value)

        $axios.put(`/project/${id}/title`, {
            "title": e.target.value,
        })
    }

    const clearProjectTemplate = () => {
        if (confirm('Delete everything?')) {
            renderTemplate("<div></div>")
        }
    }

    const changeProjectPrivacy = (e) => {
        e.preventDefault()

        $axios.put(`/project/${id}/public`, {
            "title": projectTitle,
            "description": projectOtherData.description,
            'allowComments': projectOtherData.allowComments,
            "isPublic": project.isPublic ? false : true
        })
        
        navigate(`/profile/${authUsername}/projects/${id}`)
    }

    const changeMainMenu = (type) => {
        setMainMenu(type)

        console.log(type)
    }

    return (
        <div className={styles.page}>

            {projectPrivacyWindow&& (
                <form method="POST" className={styles.page__window}>
                    <div className={styles.page__window__header}>
                        <h2>Publish file</h2>
                        <button onClick={() => setProjectPrivacyWindow(projectPrivacyWindow ? false : true)}><IoCloseCircleOutline /></button>
                    </div>
                    <div className={styles.page__window__body}>

                        <div className={styles.form__component}>
                            <label htmlFor="">Title:</label>
                            <input 
                                type="text"
                                value={projectTitle}
                                onChange={changeProjectTitle}
                                placeholder="Enter project's title"
                                required  />
                        </div>

                        <div className={styles.form__component}>
                            <label htmlFor="">Description:</label>
                            <textarea 
                                value={projectOtherData.description}
                                onChange={e => setProjectOtherData({...projectOtherData, description: e.target.value})}
                                placeholder="Enter project's description"
                                ></textarea>
                        </div>

                        <div className={styles.form__component}>
                            <label htmlFor="">Allow Comments:</label>
                            <input 
                                type="checkbox"
                                onChange={e => setProjectOtherData({...projectOtherData, allowComments: e.target.checked})}
                                checked={projectOtherData.allowComments}
                                required  />
                        </div>

                    </div>
                    <div className={styles.page__window__header}>
                        <p>You're publishing as the <b>{authUsername}</b> profile</p>
                        <div className="">
                            <button onClick={() => setProjectPrivacyWindow(projectPrivacyWindow ? false : true)}>
                                Cancel
                            </button>
                            <button onClick={changeProjectPrivacy}>
                                Publish
                            </button>
                        </div>
                    </div>
                </form>
            ) }

            <div className={styles.page__top}>

                <div className={styles.page__top__left}>
                    <button onClick={() => {navigate('/dashboard')}}>
                        <GrAppsRounded /> 
                    </button>
                </div>

                <div className={styles.page__top__center}>
                    <input 
                        type="text" 
                        value={projectTitle}
                        onChange={changeProjectTitle}
                        placeholder="Enter project's title"
                        />
                </div>

                <div className={styles.page__top__right}>
                    <button onClick={() => setProjectPrivacyWindow(projectPrivacyWindow ? false : true)}><RiShareForwardLine /></button>
                    <button onClick={clearProjectTemplate}><FaRegTrashAlt /></button>
                </div>
                
            </div>

            <div className={styles.page__footer}>
                <div className={styles.page__footer__left}>
                    <div className={styles.page__footer__left__main}>
                        <button 
                            className={mainMenu == 'ProjectStructure' ? styles.active : ''}
                            onClick={() => changeMainMenu('ProjectStructure')}>
                            <LuLayoutList />
                        </button>
                        <button 
                            className={mainMenu == 'ElementsMenu' ? styles.active : ''}
                            onClick={() => changeMainMenu('ElementsMenu')}>
                            <AiOutlineAppstoreAdd />
                        </button>
                    </div>
                    <div className={styles.page__footer__left__others}>
                        
                    </div>
                </div>
                <div 
                    className={styles.page__footer__center} >
                    <div className={styles.maket}
                    dangerouslySetInnerHTML={{ __html: projectData }}></div>
                </div>
                <div className={styles.page__footer__right}></div>
            </div>
        </div>
    )
} 

export default Constructor