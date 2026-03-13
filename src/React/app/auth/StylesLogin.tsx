import { useState, useEffect } from "react";

interface StylesLoginProps {
  force: boolean;
}

const StylesLogin = ({ force = false }: StylesLoginProps) => {
   const [shouldShowStyles, setShouldShowStyles] = useState(force);

  useEffect(() => {
    const checkUrl = () => {
      try {
        const pathname = window.location.pathname.toLowerCase();
        const isLoginPage = pathname === '/' || pathname === '/auth'|| pathname === '/auth.html';
        const newShouldShow = isLoginPage || force;
        
        setShouldShowStyles(newShouldShow);
        
        // Adiciona/remove classe login-active no body
        if (isLoginPage || force) {
          document.body.classList.add('login-active');
        } else {
          document.body.classList.remove('login-active');
        }
      } catch (error) {
        console.warn('Error checking URL:', error);
        // Em caso de erro, usa o valor force como fallback
        setShouldShowStyles(force);
        if (force) {
          document.body.classList.add('login-active');
        }
      }
    };

    // Verifica inicialmente
    checkUrl();
    
    // Monitora mudanças na URL com polling mais frequente para iOS
    const interval = setInterval(checkUrl, 50);
    
    // Escuta eventos de navegação (apenas popstate existe nativamente)
    const handlePopState = () => {
      // Delay para garantir que a URL já foi atualizada
      setTimeout(checkUrl, 10);
    };
    
    window.addEventListener('popstate', handlePopState);
    
    // Override dos métodos history para capturar navegação programática
    const originalPushState = history.pushState;
    const originalReplaceState = history.replaceState;
    
    history.pushState = function(...args) {
      originalPushState.apply(history, args);
      // Múltiplos timeouts para garantir compatibilidade com iOS
      setTimeout(checkUrl, 0);
      setTimeout(checkUrl, 10);
      setTimeout(checkUrl, 50);
    };
    
    history.replaceState = function(...args) {
      originalReplaceState.apply(history, args);
      // Múltiplos timeouts para garantir compatibilidade com iOS
      setTimeout(checkUrl, 0);
      setTimeout(checkUrl, 10);
      setTimeout(checkUrl, 50);
    };
    
    // Listener para mudanças de visibilidade (útil no iOS)
    const handleVisibilityChange = () => {
      if (!document.hidden) {
        setTimeout(checkUrl, 100);
      }
    };
    
    document.addEventListener('visibilitychange', handleVisibilityChange);
    
    // Listener para focus da janela (útil no iOS quando volta de outra aba)
    const handleFocus = () => {
      setTimeout(checkUrl, 100);
    };
    
    window.addEventListener('focus', handleFocus);
    
    return () => {
      clearInterval(interval);
      window.removeEventListener('popstate', handlePopState);
      document.removeEventListener('visibilitychange', handleVisibilityChange);
      window.removeEventListener('focus', handleFocus);
      history.pushState = originalPushState;
      history.replaceState = originalReplaceState;
      // Remove a classe ao desmontar o componente
      document.body.classList.remove('login-active');
    };
  }, [force]);
  
  if (!shouldShowStyles) return null;

  
  return <>

    <style>
      {`
       
.login-image { background-image: url('/images/fundoApp${process.env.NEXT_PUBLIC_BK_SEXO}.webp'); }       

:root {  
  --text-color: #323130;
  --text-light: #605e5c;
  --bg-light: var(--bg-forms);
  --bg-white: #ffffff;
  --border-color: #e1dfdd;
  --shadow-sm: 0 2px 4px rgba(0, 0, 0, 0.1);
  --shadow-md: 0 4px 8px rgba(0, 0, 0, 0.12);
  --border-radius: 4px;
  --spacing-xs: 2px;
  --spacing-sm: 4px;
  --spacing-md: 8px;
  --spacing-lg: 16px;
  --spacing-xl: 24px;
  --font-base: 16px; /* Aumentado para evitar zoom no iOS */
  --transition: all 0.2s ease-in-out;
}

.login-prod-text {
  font-size: 0.875rem;
  line-height: 1.5;
  color: var(--kendo-color-on-base);
  text-align: center;
  margin-bottom: var(--spacing-xl);
}
/* Reset básico e prevenção de scroll */
body, html {
  margin: 0;
  padding: 0;
  height: 100%;
  width: 100%;
  min-width: 100vw;
  overflow: hidden; /* Impede o scroll da página */
  -webkit-overflow-scrolling: touch; /* Melhora o scroll em iOS */
  -webkit-text-size-adjust: 100%; /* Previne ajuste automático de texto */ 
  }

/* Definição de altura para evitar "dança" */
body {
  height: 100vh; /* Altura fixa para viewport */
  height: -webkit-fill-available; /* Solução para Safari no iOS */
  min-height: -webkit-fill-available;
}

/* Definição explícita para iOS */
html {
  height: -webkit-fill-available;
}

/* Container principal do login com tamanho fixo e sem scroll */
.login-container {
  display: flex;
  flex-direction: row;
  height: 100%; /* Usa toda a altura disponível */
  min-height: 100vh; /* Fallback para navegadores antigos */
  min-height: -webkit-fill-available; /* Solução para Safari no iOS */
  width: 100%; /* Largura fixa na viewport */
   overflow: hidden; /* Impede scroll */
  position: fixed; /* Fixa a posição absoluta na viewport */
  top: 0;
  left: 0;
}

/* Formulário de login com tamanho fixo e previsível */
.login-form {
  flex: 1;
  width: 100%; /* Define largura total */
  max-width: 400px;
  
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
  padding: var(--spacing-xl); 
  background-color: var(--bg-white);
  box-shadow: var(--shadow-md);
  position: relative;
  z-index: 1;
  height: 100vh; /* Altura fixa */
  height: -webkit-fill-available;
  overflow: hidden; /* Permite scroll apenas dentro do formulário se necessário */
  -webkit-overflow-scrolling: touch; 
  background-color: var(--bg-forms) !important ;
}

.login-form h2 {
  margin-bottom: var(--spacing-lg);
  color: var(--text-color);
  font-weight: 500;
  font-size: 24px;
  line-height: 32px;
}

/* Grupos de formulário */
.form-group {
  margin-bottom: var(--spacing-lg);
  width: 100%; /* Largura fixa */
}

.form-group label {
  display: block;
  margin-bottom: var(--spacing-xs);
  color: var(--text-color);
  font-weight: 500;
  font-size: var(--font-base);
}

/* Campos de entrada com tamanho fixo e fonte grande suficiente */
.form-group input,
.input-login {
  width: 100%;
  box-sizing: border-box;
  padding: var(--spacing-sm) var(--spacing-md);
  border: 1px solid var(--border-color);
  border-radius: var(--border-radius);
  font-size: 16px !important; /* Importante: evita zoom no iOS */
  line-height: 1.5;
  height: 40px; /* Altura fixa para evitar redimensionamento */
  margin-bottom: var(--spacing-md);
  outline: none;
  transition: var(--transition);
  -webkit-appearance: none; /* Remove estilo padrão em iOS */
  -moz-appearance: none;
  appearance: none;
}

.form-group input:focus,
.input-login:focus {
  border-color: var(--primary-light);
  box-shadow: 0 0 0 1px var(--primary-light);
}

/* Estilos padronizados para todos os botões */
.login-form button, 
.btnLogin, 
.login-form .k-button {
  padding: 10px 15px;
  height: 40px; /* Altura fixa */
  background-color: var(--primary-light);
  color: white;
  border: none;
  border-radius: var(--border-radius);
  cursor: pointer;
  font-weight: 500;
  font-size: var(--font-base);
  transition: var(--transition);
  text-align: center;
  line-height: 20px;
  display: inline-flex;
  align-items: center;
  justify-content: center;
  -webkit-appearance: none; /* Remove estilo padrão em iOS */
  -webkit-tap-highlight-color: transparent; /* Remove highlight ao tocar */
}

button:hover, 
.btnLogin:hover, 
.k-button:hover {
  background-color: var(--primary-hover);
}

/* Botão de login - largura fixa definida */
.btnLogin {
  width: 180px !important;
  margin-top: var(--spacing-md);
}

/* Logo com posição fixa e dimensões definidas */
.login-logo-image {
  width: 100%;
  max-width: 100%;
  height: 64px;
  min-height: 64px;
  margin-top: var(--spacing-md); /* Valor fixo em vez de pixels específicos */
  margin-bottom: var(--spacing-md);
  background-repeat: no-repeat;
  background-size: contain;
  background-image: url('/images/Logo64.webp');
  background-position: center;
  display: block;
}

/* Links com tamanhos fixos de fonte */
.linkNaoSouEu,
.linkEmpresa {
  font-size: 0.875rem;
  line-height: 1.5;
  color: var(--text-dark); 
}

.linkNaoSouEu, .link-cadastro {
  margin-top: var(--spacing-xl);
  display: block;
  text-decoration: underline dotted;
  cursor: pointer;
  color: var(--primary-light);
}

.login-wellcome {
  font-size: 1.525rem;
  line-height: 1.5;
  font-weight: 700; 
  text-align: center;
  margin-bottom: var(--spacing-sm);
  color: var(--kendo-color-on-base);
}

.login-wellcome-message, 
.login-wellcome-message-2 {
  font-size: 0.875rem;
  line-height: 1.5;
 color: var(--kendo-color-on-base);
  text-align: center;
  margin-bottom: var(--spacing-lg);
}

/* Imagem de fundo com comportamento previsível */
.login-image {
  flex: 1;
  background-size: cover;
  background-position: center;
  position: relative;
  overflow: hidden;
  background-image: url('/images/fundoApp${process.env.NEXT_PUBLIC_BK_SEXO}.webp');
}

.login-footer {
  position: absolute;
  bottom: 20px;
  left: 10px;
  font-size: 0.5rem;  
  display: none;
  width: 100%;
  text-align: center;
} 

.footer-powered {
  margin: 0;
  padding: 0;
  font-size: 0.575rem;
  line-height: 1.5;
  text-align: center;
  height: 22px;
  min-height: 36px;
  padding-bottom: 4px;
  margin-bottom: 10px;
}

.login-cadastrese {    
  left: 10px;  
  display: block;
  width: 100%;
  text-align: center;    
  margin-bottom: var(--spacing-xl);
} 

.login-cadastrese p {
  font-size: 0.75rem !important;  
}

.footer-text {
  margin: 0;
  padding: 0;
  font-size: 0.575rem;
  line-height: 1.5;
  text-align: center;
}

.linkEmpresa, .link-cadastro {
  display: inline-block;
  color: var(--primary-light);
  font-size: 0.75rem;  
  text-decoration: none;    
  transition: 
    background 0.2s,
    color 0.2s,
    box-shadow 0.2s;
  box-shadow: 0 1px 4px rgba(0,120,212,0.06);
  margin: 8px 0;
  cursor: pointer;
}

.linkEmpresa:hover,
.linkEmpresa:focus {
 
  box-shadow: 0 2px 8px rgba(0,120,212,0.15);
  text-decoration: none;
  outline: none;
}

/* Media Queries com comportamento mais consistente */
@media (max-width: 992px) {
  .login-form {
    max-width: 390px;
  }
}

@media (max-width: 768px) {
  .login-container {
    flex-direction: column;
  } 

  .login-form {     
    width: 100% !important;  
    height: 100vh;
    min-width: 100%;
    height: -webkit-fill-available; 
  }

  .login-image {
    display: none;
  }
  
  .login-logo-image {
    margin-top: var(--spacing-lg);
    margin-bottom: var(--spacing-lg);
  }
}

@media (max-width: 480px) {
  .login-form {
    padding: var(--spacing-md);
  }
  
  .btnLogin {
    width: 100% !important;
  }
  
  .login-logo-image {
    margin-top: var(--spacing-md);
  } 
}

/* Classes de visibilidade para controle de exibição */
.show-footer {
  display: block;
}

/* Mensagens de autenticação com tamanho consistente */
.auth-message {
  font-size: 0.875rem;
  line-height: 1.5;
  margin-bottom: var(--spacing-md);
}

.button-continue {  
  max-width: 400px;
}

.button-continue button {
  text-align: center;
  margin-left: auto;
  margin-right: auto;
  max-width: 400px;  
  width: 140px;    
}

.login-top1 {
  display: flex;
  height: 10vh;
  width: 100%;
  justify-content: center;
}

.login-container input, .login-container .k-input {
  width: 80vw !important;
  max-width: 360px !important;
}
   
      `}
    </style>
  </>;
};

export default StylesLogin;