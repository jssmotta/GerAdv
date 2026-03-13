'use client';
import axios, { AxiosError, InternalAxiosRequestConfig } from 'axios';

let interceptorId: number | null = null;

/**
 * URLs que devem ser ignoradas pelo interceptor de logout automático
 * Estas são rotas de autenticação onde 401 é esperado
 */
const IGNORED_URLS = [
  '/users/authenticate',
  '/users/authenticate3',
  '/users/validausername',
  '/users/resetpassword',
  '/users/changepassword',
  '/users/reset',
];

/**
 * Verifica se a URL deve ser ignorada pelo interceptor
 */
const shouldIgnoreUrl = (url?: string): boolean => {
  if (!url) return false;
  return IGNORED_URLS.some(ignoredUrl => url.includes(ignoredUrl));
};

/**
 * Configura o interceptor global do Axios para tratar erros 401 (token expirado)
 * @param onUnauthorized Callback que será executado quando detectar um 401
 */
export const setupAxiosInterceptor = (onUnauthorized: () => void) => {
  // Remove o interceptor anterior se existir
  if (interceptorId !== null) {
    axios.interceptors.response.eject(interceptorId);
  }

  // Adiciona novo interceptor de resposta para capturar erros 401
  interceptorId = axios.interceptors.response.use(
    (response) => {
      // Se a resposta for bem-sucedida, apenas retorna
      return response;
    },
    (error: AxiosError) => {
      const requestUrl = error.config?.url;
      const statusCode = error.response?.status;
      
      // APENAS erro 401 (Unauthorized - token expirado) faz logout
      // Ignora 404, 500 e outros erros
      // Também ignora rotas de autenticação
      if (statusCode === 401 && !shouldIgnoreUrl(requestUrl)) {
        if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.log('Token expirado detectado (401) - executando logout');
          console.log('URL:', requestUrl);
        }

        // Executa o callback de logout IMEDIATAMENTE
        try {
          onUnauthorized();
        } catch (err) {
          console.error('Erro ao executar logout:', err);
        }
      } else if (process.env.NEXT_PUBLIC_SHOW_LOG === '1' && statusCode) {
        console.log(`Erro ${statusCode} ignorado pelo interceptor`);
      }

      // Rejeita a promise para que o erro continue sendo tratado normalmente
      return Promise.reject(error);
    }
  );

  if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
    console.log('Axios interceptor configurado com sucesso, ID:', interceptorId);
  }
};

/**
 * Remove o interceptor (útil para testes ou cleanup)
 */
export const removeAxiosInterceptor = () => {
  if (interceptorId !== null) {
    axios.interceptors.response.eject(interceptorId);
    interceptorId = null;
  }
};
