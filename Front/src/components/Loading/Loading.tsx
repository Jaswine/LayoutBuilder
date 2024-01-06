import { FC } from "react"
import styles from './Loading.module.scss'

const Loading:FC = () => {
  return (
    <div>
      <div className={styles.lds_facebook}><div></div><div></div><div></div></div>
    </div>
  )
}

export default Loading