
interface AuthContextProps {
    isAuth: boolean;
    setIsAuth: React.Dispatch<React.SetStateAction<boolean>>;
    authUsername: string;
    setAuthUsername: React.Dispatch<React.SetStateAction<string>>;
    authEmail: string;
    setAuthEmail: React.Dispatch<React.SetStateAction<string>>;
  }

export default AuthContextProps