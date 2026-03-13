'use client';
import React, { useEffect, useState, useRef } from 'react';
import { useRouter } from 'next/navigation';
import AuthContainer from './AuthContainer';
import HotjarComponent from '../tools/Hotjar';
import GAComponent from '../tools/GA';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { selectSystemContext, setSystemContext, setDiaAgenda } from '../store/slices/systemContextSlice';
import { iniciaBarraAgendaSemanaData } from '../tools/helpers';
import { useIsMobile } from '../context/MobileContext';
import { useAuth, AuthStatus } from './AuthProvider';
import { MustChangePasswordChecked } from './tools/userControl';


export const AuthRedirector: React.FC = () => {
  const dispatch = useAppDispatch();
  const systemContext = useAppSelector(selectSystemContext);
  const { authStatus, setAuthStatus } = useAuth();
  const router = useRouter();

  const redirectionKey = 'auth_redirection_attempted';

  useEffect(() => {
    // Verificando se usuário está logado via systemContext E authStatus
    const isLoggedIn =
      systemContext !== null && authStatus === AuthStatus.LOGGED_IN;

    if (authStatus === AuthStatus.VALIDATING_USERNAME) {
      dispatch(setSystemContext(null));
      return;
    }

    if (!isLoggedIn && authStatus !== AuthStatus.LOGGED_IN) {
      localStorage.removeItem(redirectionKey);
    }
    
     if (MustChangePasswordChecked()) {
      setAuthStatus(AuthStatus.PASSWORD_RESET_REQUIRED);
    }

  }, [systemContext, authStatus, router]);

  return null; // Este componente não renderiza nada visualmente
};

 

interface LoginUIProps {
  changePassword?: boolean;
}
/**
 * Componente LoginUI atualizado
 * - Segue o princípio da Responsabilidade Única (S do SOLID)
 * - Delega autenticação para o AuthProvider
 * - Delega renderização dos formulários para AuthContainer
 */
const LoginUI: React.FC<LoginUIProps> = ({ changePassword }) => {
  const dispatch = useAppDispatch();
  const isMobile = useIsMobile();

  // Inicializar agenda quando o componente montar
  useEffect(() => {
    dispatch(setDiaAgenda(iniciaBarraAgendaSemanaData(isMobile)));
  }, [isMobile, dispatch]);

  // Prefetch para melhorar a performance
  useEffect(() => {
    const link = document.createElement('link');
    link.rel = 'dns-prefetch';
    link.href = process.env.NEXT_PUBLIC_URL_API_FETCH ?? '';
    document.head.appendChild(link);
  }, []);

  return (
    <>
      <AuthRedirector />
      <GAComponent />
      <AuthContainer />
      <HotjarComponent />
    </>
  );
};

export default LoginUI;
