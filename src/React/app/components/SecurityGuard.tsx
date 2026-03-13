'use client';
import { useEffect, useState } from 'react';

/**
 * Componente de segurança global que deve ser incluído no layout principal
 * Intercepta navegações e formulários que possam expor dados sensíveis
 */
export default function SecurityGuard() {
  const [isClient, setIsClient] = useState(false);

  useEffect(() => {
    // Marca que estamos no cliente
    setIsClient(true);
  }, []);

  useEffect(() => {
    // Só executa no cliente
    if (!isClient) return;
    // Lista de palavras sensíveis
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
    const containsSensitiveData = (url: string): boolean => {
      const lowerUrl = url.toLowerCase();
      return sensitiveKeywords.some(keyword => 
        lowerUrl.includes(keyword.toLowerCase())
      );
    };

    /**
     * Intercepta mudanças na URL
     */
    const handleUrlChange = () => {
      const currentUrl = window.location.href;
      
      if (containsSensitiveData(currentUrl)) {
        console.error('🚨 SECURITY GUARD: Sensitive data detected in URL! Cleaning...', currentUrl);
        
        // Limpa a URL removendo todos os parâmetros
        const cleanUrl = window.location.protocol + '//' + 
                        window.location.host + 
                        window.location.pathname;
        
        // Substitui a URL atual pela versão limpa
        window.history.replaceState({}, document.title, cleanUrl);
        
        // Se for uma página de alteração de senha, redireciona para login
        if (currentUrl.includes('/auth/cp')) {
          setTimeout(() => {
            window.location.replace('/auth');
          }, 100);
        }
      }
    };

    /**
     * Intercepta submissão de formulários para garantir que usem POST
     */
    const interceptFormSubmissions = () => {
      const forms = document.querySelectorAll('form');
      
      forms.forEach(form => {
        // Remove listeners existentes para evitar duplicação
        const existingListener = form.getAttribute('data-security-listener');
        if (existingListener === 'true') return;
        
        form.setAttribute('data-security-listener', 'true');
        
        form.addEventListener('submit', (e) => {
          // Força método POST para formulários de login/senha
          if (form.method && form.method.toUpperCase() !== 'POST') {
            if (form.querySelector('input[type="password"]')) {
              console.warn('🚨 SECURITY GUARD: Forcing form method to POST for password form');
              form.method = 'post';
            }
          }
          
          // Verifica se há dados sensíveis no action da form
          if (form.action && containsSensitiveData(form.action)) {
            console.error('🚨 SECURITY GUARD: Form action contains sensitive data! Blocking submission.');
            e.preventDefault();
            return false;
          }
          
          // Adiciona atributos de segurança se não existirem
          if (!form.hasAttribute('novalidate')) {
            form.setAttribute('novalidate', '');
          }
          if (!form.hasAttribute('autocomplete')) {
            form.setAttribute('autocomplete', 'off');
          }
        });
      });
    };

    /**
     * Intercepta navegações programáticas
     */
    const interceptNavigation = () => {
      // Intercepta métodos de navegação sem redefinir propriedades
      const originalPushState = window.history.pushState;
      const originalReplaceState = window.history.replaceState;
      
      // Override history.pushState
      window.history.pushState = function(state, title, url) {
        if (url && typeof url === 'string' && containsSensitiveData(url)) {
          console.error('🚨 SECURITY GUARD: Blocked pushState with sensitive data!', url);
          return;
        }
        return originalPushState.call(this, state, title, url);
      };
      
      // Override history.replaceState
      window.history.replaceState = function(state, title, url) {
        if (url && typeof url === 'string' && containsSensitiveData(url)) {
          console.error('🚨 SECURITY GUARD: Blocked replaceState with sensitive data!', url);
          return;
        }
        return originalReplaceState.call(this, state, title, url);
      };
      
      // Restaura métodos originais no cleanup
      return () => {
        window.history.pushState = originalPushState;
        window.history.replaceState = originalReplaceState;
      };
    };

    // Executa verificações iniciais apenas no cliente
    if (typeof window !== 'undefined') {
      // Pequeno delay para garantir que o DOM está pronto
      setTimeout(() => {
        handleUrlChange();
        interceptFormSubmissions();
      }, 100);
      
      // Setup da interceptação de navegação
      const cleanupNavigation = interceptNavigation();

      // Monitora mudanças na URL
      window.addEventListener('popstate', handleUrlChange);
      window.addEventListener('hashchange', handleUrlChange);
      
      // Observer para novos formulários adicionados dinamicamente
      const observer = new MutationObserver((mutations) => {
        let shouldCheckForms = false;
        
        mutations.forEach((mutation) => {
          if (mutation.type === 'childList') {
            mutation.addedNodes.forEach((node) => {
              if (node.nodeType === Node.ELEMENT_NODE) {
                const element = node as Element;
                if (element.tagName === 'FORM' || element.querySelector('form')) {
                  shouldCheckForms = true;
                }
              }
            });
          }
        });
        
        if (shouldCheckForms) {
          setTimeout(interceptFormSubmissions, 0);
        }
        
        // Verifica URL após mudanças no DOM que possam causar navegação
        setTimeout(handleUrlChange, 0);
      });
      
      // Aguarda o body estar disponível
      if (document.body) {
        observer.observe(document.body, { 
          subtree: true, 
          childList: true 
        });
      }

      // Cleanup
      return () => {
        window.removeEventListener('popstate', handleUrlChange);
        window.removeEventListener('hashchange', handleUrlChange);
        observer.disconnect();
        if (cleanupNavigation) {
          cleanupNavigation();
        }
      };
    }
  }, [isClient]);

  // Este componente não renderiza nada visível
  return null;
}