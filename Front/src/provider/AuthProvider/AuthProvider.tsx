import { FC, useState, createContext, useEffect} from "react";
import AuthContextProps from "./AuthProviderInterface";

export const AuthContext = createContext<AuthContextProps>({} as AuthContextProps);

const AuthProvider: FC = ({ children }) => {
    const [isAuth, setIsAuth] = useState<boolean>( localStorage.getItem('authToken')? true : false );
    const [authUsername, setAuthUsername] = useState<string>(localStorage.getItem('authUsername') || '')
    const [authEmail, setAuthEmail] = useState<string>(localStorage.getItem('authEmail') || '')

    return (
        <AuthContext.Provider value={{isAuth, setIsAuth, authUsername, setAuthUsername, authEmail, setAuthEmail}}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthProvider