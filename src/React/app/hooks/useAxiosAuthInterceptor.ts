'use client';
import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useAuth, AuthStatus } from '../auth/AuthProvider';
import { useAppDispatch } from '../store/hooks';
import { setLoginEmail, setSystemContext } from '../store/slices/systemContextSlice';
import { setupAxiosInterceptor } from '../services/axiosInterceptor';

/**
 * Hook que configura o interceptor do Axios para fazer logout automático quando o token expira
 * Deve ser usado uma única vez no componente raiz da aplicação
 * O interceptor só é ativado quando o usuário está logado
 */
export const useAxiosAuthInterceptor = () => {
  const router = useRouter();
  const { logout, user, authStatus } = useAuth();
  const dispatch = useAppDispatch();

  useEffect(() => {
    // Só configura o interceptor se o usuário estiver logado
    if (authStatus === AuthStatus.LOGGED_IN && user) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.log('Configurando interceptor - usuário logado:', user.Username);
      }

      const handleUnauthorized = () => {
        if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.log('handleUnauthorized chamado!');
        }

        // Executa o logout completo
        logout();
        dispatch(setLoginEmail(null));
        dispatch(setSystemContext(null));
        
        // Redireciona para a página de login
        router.push('/auth');
        router.refresh();
      };

      // Configura o interceptor
      setupAxiosInterceptor(handleUnauthorized);
    }
  }, [authStatus, user, logout, setLoginEmail, setSystemContext, router]);
};
