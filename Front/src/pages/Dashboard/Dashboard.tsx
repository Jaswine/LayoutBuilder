import { FC, useEffect } from "react";
import { useAuth } from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

const Dashboard:FC = () => {
    const navigate = useNavigate()
    const {isAuth} = useAuth()

    useEffect(() => {
        document.title = 'Dashboard'

        isAuth && navigate('/')
    }, [])

    return (
        <div>
            Dashboard
        </div>
    )
}

export default Dashboard
