'use client';
import React, {
  createContext,
  useContext,
  ReactNode,
  useState,
  useEffect,
} from 'react';
import { UserModel } from '../models/userModel';
import {
  authServiceAdapter,
  AuthStatus,
  CaptchaStatus,
} from './AuthServiceAdapter';
import { MustChangePasswordChecked } from '@/app/auth/tools/userControl';
import { MustChangePassword } from './api/authApi';
interface AuthContextType {
  user: UserModel | null;
  tenant: string | null;
  authStatus: AuthStatus;
  email: string | null;
  captchaStatus: CaptchaStatus;
  errorMessage: string | null;
  setEmail: (tenant: string | null, email: string | null) => void;
  setTenant: (tenant: string | null) => void;
  setCaptchaStatus: (status: CaptchaStatus) => void;
  setErrorMessage: (message: string | null) => void;
  validateUsername: (dominio: string, email: string) => Promise<boolean>;
  login: (tenant: string, password: string) => Promise<boolean>; // Retorna boolean indicando sucesso
  requestPasswordReset: (tenant: string) => Promise<void>;
  logout: () => void;
  changeStatus: (status: any) => void;
  forceLoggedInStatus: () => void;
  setAuthStatus: (status: AuthStatus) => void;
}

const APP_ID = process.env.NEXT_PUBLIC_APP_GLOBAL ?? 'APP_ID';

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (context === undefined) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [user, setUser] = useState<UserModel | null>(() => {
    if (typeof window !== 'undefined' && window.localStorage) {
      const savedUser = localStorage.getItem(btoa(`${APP_ID}systemContext`));
      return savedUser ? JSON.parse(savedUser) : null;
    }
    return null;
  });

  const [tenant, setTenant] = useState<string | null>(() => {
    if (typeof window !== 'undefined' && window.localStorage) {
      const savedTenant = localStorage.getItem(btoa(`${APP_ID}loginTenant`));
      return savedTenant ? JSON.parse(savedTenant) : null;
    }
    return null;
  });

  const [authStatus, setAuthStatus] = useState<AuthStatus>(() => {
    return user ? AuthStatus.LOGGED_IN : AuthStatus.LOGGED_OUT;
  });

  const [email, setEmail] = useState<string | null>(() => {
    if (typeof window !== 'undefined' && window.localStorage) {
      const savedEmail = localStorage.getItem(btoa(`${APP_ID}loginEmail0`));
      return savedEmail ? JSON.parse(savedEmail) : null;
    }
    return null;
  });

  const [captchaStatus, setCaptchaStatus] = useState<CaptchaStatus>(
    process.env.NEXT_PUBLIC_RECAPTCHA_SITE_KEY === undefined
      ? CaptchaStatus.VERIFIED
      : CaptchaStatus.WAITING
  );

  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const [wrongPassword, setwrongPassword] = useState<boolean>(false);

  const forceLoggedInStatus = () => {
    setAuthStatus(AuthStatus.LOGGED_OUT);
  };

  useEffect(() => {
    if (typeof window !== 'undefined') {
      if (user) {
        localStorage.setItem(
          btoa(`${APP_ID}systemContext`),
          JSON.stringify(user)
        );
      } else {
        localStorage.removeItem(btoa(`${APP_ID}systemContext`));
      }
    }
  }, [user]);

  useEffect(() => {
    if (typeof window !== 'undefined') {
      if (email) {
        localStorage.setItem(
          btoa(`${APP_ID}loginEmail0`),
          JSON.stringify(email)
        );
      } else {
        localStorage.removeItem(btoa(`${APP_ID}loginEmail0`));
      }
    }
  }, [email]);

  useEffect(() => {
    if (typeof window !== 'undefined') {
      if (tenant) {
        localStorage.setItem(btoa(`${APP_ID}loginTenant`), JSON.stringify(tenant));
      } else {
        localStorage.removeItem(btoa(`${APP_ID}loginTenant`));
      }
    }
  }, [tenant]);

  useEffect(() => {
    if (user) {
      if (MustChangePasswordChecked()) {
        setAuthStatus(AuthStatus.PASSWORD_RESET_REQUIRED);
      } else {
        setAuthStatus(AuthStatus.LOGGED_IN);
      }
    } else if (email) {
      setAuthStatus(AuthStatus.VALIDATING_PASSWORD);
    } else {
      setAuthStatus(AuthStatus.VALIDATING_USERNAME);
    }
  }, [user, email]);

  // Função para atualizar o email e o status de autenticação juntos
  const updateEmail = (tenant: string | null, newEmail: string | null) => {
    setEmail(newEmail);
    setTenant(tenant);

    // Atualizar o authStatus diretamente com base no novo valor do email
    if (newEmail) {
      setAuthStatus(AuthStatus.VALIDATING_PASSWORD);
    } else {
      setAuthStatus(AuthStatus.VALIDATING_USERNAME);
    }
  };

  // Ações de autenticação
  const validateUsername = async (
    tenant: string,
    emailToValidate: string
  ): Promise<boolean> => {
    try {
      setErrorMessage(null);
      const isValid = await authServiceAdapter.validateUsername(
        emailToValidate,
        tenant,
        setErrorMessage
      );

      if (isValid) {
        updateEmail(tenant, emailToValidate);
        return true;
      }

      // If adapter returned false but did not set a message, provide a default one
      setErrorMessage((prev) => prev ?? 'Usuário desconhecido ou sem acesso.');
      return false;
    } catch (error) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
        console.log('Erro na validação de email');
      return false;
    }
  };

  const login = async (tenant: string, password: string): Promise<boolean> => {
    if (!email) return false;

    try {
      setErrorMessage(null);

      const loginSuccess = await new Promise<boolean>((resolve) => {
        authServiceAdapter
          .login(
            { email, password },
            tenant,
            (userData) => {
              if (userData) {
                var localUser = userData as UserModel;
                setUser(localUser);
                setTenant(tenant);

                // VERIFICAR IMEDIATAMENTE SE PRECISA TROCAR SENHA
                MustChangePassword(localUser).then((mustChange) => {
                  if (mustChange) {
                    MustChangePasswordChecked(true);
                    setAuthStatus(AuthStatus.PASSWORD_RESET_REQUIRED);
                  } else {
                    setAuthStatus(AuthStatus.LOGGED_IN);
                  }
                });

                resolve(true);
              } else {
                resolve(false);
              }
            },
            setwrongPassword,
            setErrorMessage
          )
          .then((success) => {
            if (!success) resolve(false);
          })
          .catch((err) => {
            if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
              console.log('Login error');
            resolve(false);
          });
      });

      return loginSuccess;
    } catch (error) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
        console.log('Erro de login');
      return false;
    }
  };


  const requestPasswordReset = async (tenant: string): Promise<void> => {
    if (!email) return;

    try {
      setErrorMessage(null);
      await authServiceAdapter.requestPasswordReset(
        email,
        tenant,
        setErrorMessage
      );
    } catch (error) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
        console.log('Erro na solicitação de reset de senha');
    }
  };

  const logout = (): void => {
    setUser(null);
    setTenant(null);
    updateEmail(null, null);
    localStorage.clear();
    sessionStorage.clear();
    setAuthStatus(AuthStatus.LOGGED_OUT);
    // 🔄 Reset do ReCaptcha para estado inicial
    setCaptchaStatus(
      process.env.NEXT_PUBLIC_RECAPTCHA_SITE_KEY === undefined
        ? CaptchaStatus.VERIFIED
        : CaptchaStatus.WAITING
    );
  };

  const changeStatus = (status: any): void => {
    setAuthStatus(status);
  };

  const value = {
    user,
    authStatus,
    tenant,
    email,
    captchaStatus,
    errorMessage,
    setTenant,
    setEmail: updateEmail,
    setCaptchaStatus,
    setErrorMessage,
    validateUsername,
    login,
    requestPasswordReset,
    logout,
    changeStatus,
    forceLoggedInStatus, // Exportando o novo método
    setAuthStatus, // Exportando o método para setar o status de autenticação
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

// Exportar o enum para uso em outros componentes
export { AuthStatus, CaptchaStatus };
