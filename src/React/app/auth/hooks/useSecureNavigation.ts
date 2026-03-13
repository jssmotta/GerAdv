'use client';
import { useRouter } from 'next/navigation';
import { useCallback, useEffect } from 'react';

/**
 * Hook para detectar e prevenir navegações que contenham dados sensíveis na URL
 */
export const useSecureNavigation = () => {
  const router = useRouter();

  // Lista de palavras que indicam dados sensíveis na URL
  const sensitiveKeywords = [
    'password', 
    'currentPassword', 
    'passwordNew', 
    'passwordConfirm',
    'senha',
    'token',
    'access_token',
    'refresh_token',
    'secret',
    'key'
  ];

  /**
   * Verifica se uma URL contém dados sensíveis
   */
  const containsSensitiveData = useCallback((url: string): boolean => {
    const lowerUrl = url.toLowerCase();
    return sensitiveKeywords.some(keyword => 
      lowerUrl.includes(keyword.toLowerCase())
    );
  }, []);

  /**
   * Intercepta mudanças na URL para detectar dados sensíveis
   */
  useEffect(() => {
    const handleUrlChange = () => {
      const currentUrl = window.location.href;
      
      if (containsSensitiveData(currentUrl)) {
        console.error('🚨 SECURITY ALERT: Sensitive data detected in URL!', currentUrl);
        
        // Limpa a URL removendo os parâmetros sensíveis
        const cleanUrl = window.location.protocol + '//' + 
                        window.location.host + 
                        window.location.pathname;
        
        // Redireciona para a URL limpa (remove parâmetros sensíveis)
        window.history.replaceState({}, document.title, cleanUrl);

        // Não forçar navegação para /auth a partir de /auth/cp aqui.
        // Forçar redirect para /auth fazia com que usuários na rota
        // "/auth/cp" fossem enviados para outra página (ex: /dashboard)
        // em fluxos onde o app reagia ao estado global. Mantemos o usuário
        // na rota limpa para permitir o fluxo de alteração de senha.
      }
    };

    // Verifica a URL atual
    handleUrlChange();

    // Escuta mudanças na URL
    window.addEventListener('popstate', handleUrlChange);
    
    // Observer para mudanças no DOM que possam indicar navegação
    const observer = new MutationObserver(() => {
      setTimeout(handleUrlChange, 0);
    });
    
    observer.observe(document, { 
      subtree: true, 
      childList: true 
    });

    return () => {
      window.removeEventListener('popstate', handleUrlChange);
      observer.disconnect();
    };
  }, [containsSensitiveData]);

  /**
   * Navegação segura que garante que não há dados sensíveis na URL
   */
  const secureNavigate = useCallback((path: string, options?: { replace?: boolean }) => {
    if (containsSensitiveData(path)) {
      console.error('🚨 SECURITY WARNING: Attempted navigation with sensitive data in URL blocked!', path);
      
      // Extrai apenas o caminho sem parâmetros sensíveis
      const cleanPath = path.split('?')[0];
      
      if (options?.replace) {
        router.replace(cleanPath);
      } else {
        router.push(cleanPath);
      }
      return;
    }

    if (options?.replace) {
      router.replace(path);
    } else {
      router.push(path);
    }
  }, [router, containsSensitiveData]);

  return {
    secureNavigate,
    containsSensitiveData
  };
};