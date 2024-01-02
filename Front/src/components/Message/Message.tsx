import { FC } from "react";
import styles from './Message.module.scss'
import { IoIosNotifications } from "react-icons/io";

const Message:FC = ({children}) => {
    return (
        <div className={styles.message}><IoIosNotifications /> {children}</div>
    )
}

export default Message