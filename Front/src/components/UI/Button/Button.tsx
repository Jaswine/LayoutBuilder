import { FC } from "react"
import styles from './Button.module.scss'

const Button:FC = ({onClick, children}) => {
    return (
        <button onClick={onClick} className={styles.button}>{children}</button>
    )
}

export default Button