import { FC } from "react";
import styles from './Index.module.scss'
import Header from "../../components/Index/Header/Header";
import Intro from "../../components/Index/Intro/Intro";

const Index:FC = () => {
    return (
        <div className={styles.page}>
            <Header />
            <Intro />
        </div>
    )
}

export default Index
