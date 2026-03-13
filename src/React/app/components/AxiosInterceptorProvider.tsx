'use client';
import { useAxiosAuthInterceptor } from '../hooks/useAxiosAuthInterceptor';

interface AxiosInterceptorProviderProps {
  children: React.ReactNode;
}

/**
 * Componente que inicializa o interceptor do Axios para logout automático
 * Deve ser colocado dentro dos providers de Auth e SystemContext
 */
export const AxiosInterceptorProvider: React.FC<AxiosInterceptorProviderProps> = ({ children }) => {
  useAxiosAuthInterceptor();
  return <>{children}</>;
};
