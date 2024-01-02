import { FC, useState, createContext, useEffect} from "react";
import AuthContextProps from "./AuthProviderInterface";

export const AuthContext = createContext<AuthContextProps>({} as AuthContextProps);

const AuthProvider: FC = ({ children }) => {
    const [isAuth, setIsAuth] = useState<boolean>(false)
    const [authUsername, setAuthUsername] = useState<string>("")
    const [authEmail, setAuthEmail] = useState<string>("")

    useEffect(() => {
        const authToken = localStorage.getItem('authToken')
        setIsAuth(!!authToken)

        const storedUsername = localStorage.getItem('authUsername');
        setAuthUsername(storedUsername || '');

        const storedEmail = localStorage.getItem('authEmail');
        setAuthEmail(storedEmail || '');
    }, [])

    return (
        <AuthContext.Provider value={{isAuth, setIsAuth, authUsername, setAuthUsername, authEmail, setAuthEmail}}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthProvider