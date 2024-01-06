import { FC } from "react"
import styles from './NotFound.module.scss'
import { Link } from "react-router-dom"

const NotFound:FC = () => {
  return (
    <div className={styles.NotFound}>
        <img src="/public/notfound.png" alt="not found" />
        <h1>Page Not Found</h1>
        <p>Go to <Link to='/dashboard'>Dashboard</Link>!</p>
    </div>
  )
}

export default NotFound