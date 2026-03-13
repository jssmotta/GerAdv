'use client';
import React, { use, useEffect, useState } from 'react';

import { AuthStatus, CaptchaStatus } from './AuthServiceAdapter';
import UsernameForm from './UsernameForm';
import PasswordForm from './PasswordForm';
import PasswordChangeForm from './PasswordChangeForm';
import RecaptchaUI from '../components/RecaptchaUI';
import { useAuth } from './AuthProvider';
import { useRouter } from 'next/navigation';
import { useAppDispatch, useAppSelector } from '@/app/store/hooks';
import { selectSystemContext, setSystemContext } from '@/app/store/slices/systemContextSlice';
import CreateAccountForm from './createaccount/CreateAccountForm';
import ChangePassword from './ChangePassword';
import { Button } from '@progress/kendo-react-buttons';
import { Loader } from '@progress/kendo-react-indicators';
import LoadingAnimation from './tools/LoadingAnimation';


const AuthContainer: React.FC = () => {
  const { authStatus, captchaStatus, setCaptchaStatus, logout, tenant } = useAuth();
  const router = useRouter();
  const dispatch = useAppDispatch();
  const systemContext = useAppSelector(selectSystemContext);
  const [showCss, setShowCss] = useState(systemContext == null);
  const [isClient, setIsClient] = useState(false);
  const [recaptchaKey, setRecaptchaKey] = useState(0); // 🔑 Key para forçar remontagem
  const previousAuthStatusRef = React.useRef(authStatus);

  useEffect(() => {
    // Marca que estamos no cliente para evitar problemas de hidratação
    setIsClient(true);
  }, []);

  useEffect(() => {
    if (systemContext === null) {
      setShowCss(true);
    }
    else {
      setTimeout(() => {
        setShowCss(false);
      }, 400);
    }
  }, [systemContext]);

  // 🔄 Atualizar key do RecaptchaUI APENAS quando faz LOGOUT (transição de LOGGED_IN -> LOGGED_OUT)
  useEffect(() => {
    if (previousAuthStatusRef.current === AuthStatus.LOGGED_IN && authStatus === AuthStatus.LOGGED_OUT) {
      setRecaptchaKey(prev => prev + 1);
    }
    previousAuthStatusRef.current = authStatus;
  }, [authStatus]);

  // Move hooks to top level
  const [showRefresh, setShowRefresh] = useState(false);

  const PConstTimeoutCaptcha = 5000; // 5 segundos

  // Function to convert captcha status
  const handleCaptchaSuccess = (success: number) => {
    if (success === 0) {
      setCaptchaStatus(CaptchaStatus.WAITING);
    } else if (success === 1) {
      setCaptchaStatus(CaptchaStatus.VERIFIED);
    } else {
      setCaptchaStatus(CaptchaStatus.FAILED);
    }
  };

  const updatePage = () => {
    // 🔥 MacGyver: Simular CTRL+F5 programaticamente
    if (typeof window !== 'undefined') {
      // Hard reload ignorando cache (equivalente a CTRL+F5)
      window.location.reload();
    }
  };

  // Handle redirect effect
  useEffect(() => {
    if (authStatus === AuthStatus.LOGGED_IN) {
      if (
        systemContext !== null        // MERDA
      ) {
        router.push('/auth/splash');
      }
    }
  }, [authStatus, router, systemContext]);

  // Handle timeout effect
  useEffect(() => {
    if (captchaStatus === CaptchaStatus.WAITING) {
      const timer = setTimeout(() => {
        setShowRefresh(true);
      }, PConstTimeoutCaptcha);

      return () => clearTimeout(timer);
    } else {
      setShowRefresh(false);
    }
  }, [captchaStatus]);


  const onSuccess = (): void => {
    logout();
    localStorage.setItem(
      btoa(`${process.env.NEXT_PUBLIC_APP_GLOBAL}login_success`),
      'false'
    );
    dispatch(setSystemContext(null));
    router.push('/auth');
    router.refresh();
  };

  const PTempoAutoReset = 1000;
  useEffect(() => {
    if (showRefresh) {
      const timer = setTimeout(() => {
        updatePage();
      }, PTempoAutoReset);
      return () => clearTimeout(timer);
    }
  }, [showRefresh]);


  // Render auth form based on status
  const renderAuthForm = () => {
    if (captchaStatus === CaptchaStatus.WAITING) {
      return (
        <>
          <div className="auth-message"></div>
          <br />
          <br />
          {showRefresh && (
            <>
              <Button
                onClick={updatePage}
                className="buttonOk"
                themeColor="primary"
              >
                ATUALIZAR
              </Button>
              <div className="auth-message">
                Se persistir, por favor, clique em "Atualizar"
              </div>
            </>
          )}
          {!showRefresh && <div className="auth-message"><LoadingAnimation text='Pensando...' /><br></br> <Loader size="large" type={'converging-spinner'} /></div>}
          <br />
          <br />
          <br />
          <br />
          <br />
          <h3 className="nameApp">{process.env.NEXT_PUBLIC_NOME_PRODUTO}</h3>
        </>
      );
    }

    if (captchaStatus === CaptchaStatus.FAILED) {
      return <div className="auth-message">Captcha inválido</div>;
    }

    switch (authStatus) {
      case AuthStatus.PASSWORD_RESET_REQUIRED:
        return (
          <PasswordChangeForm
            captchaSuccess={captchaStatus === CaptchaStatus.VERIFIED}
          />
        );
      case AuthStatus.CHANGING_PASSWORD:
        return <ChangePassword onSuccess={onSuccess} readCurrentPassword={true} />;
      case AuthStatus.LOGGED_IN:
        return (
          <>
            {isClient && <LoadingAnimation text='Pensando...' />}
            <Loader size="large" type={'converging-spinner'} />
          </>
        );
      case AuthStatus.VALIDATING_USERNAME:
        return <UsernameForm />;
      case AuthStatus.VALIDATING_PASSWORD:
        return (
          <PasswordForm
            captchaSuccess={captchaStatus === CaptchaStatus.VERIFIED}
          />
        );
      case AuthStatus.CREATE_ACCPOUNT:
        return (
          <CreateAccountForm
            captchaSuccess={captchaStatus === CaptchaStatus.VERIFIED}
          />
        );
      default:
        return <UsernameForm />;
    }
  };
 
  return (
 
    <RecaptchaUI key={`recaptcha-container-${recaptchaKey}`} setCaptchaSuccess={handleCaptchaSuccess}>
      <div className="login-container">
        <div className="login-form">
          <div
            className="login-logo-image"
            style={{ backgroundImage: "url('/images/Logo64.webp')" }}
          ></div>
          <div className="login-prod-text">
            {process.env.NEXT_PUBLIC_NOME_PRODUTO}
          </div>
          <div className="login-wellcome show-footer">{tenant == null ? 'Bem-vindo' : tenant}</div>
          <div className="login-wellcome-message show-footer"></div>

          {renderAuthForm()}

          <div className="login-footer show-footer">
            <div className="footer-text">
              <a
                className="linkEmpresa"
                href="https://www.menphis.com.br/"
                target="_blank"
                rel="noopener noreferrer"
              >
                www.menphis.com.br
              </a>
              &nbsp;|&nbsp;
              <a
                className="linkEmpresa"
                href={`https://api.whatsapp.com/send?phone=${process.env.NEXT_PUBLIC_WHATSAPP_NUMBER}&text=Ol%C3%A1,%20tudo%20bem???`}
                target="_blank"
                rel="noopener noreferrer"
              >
                Suporte
              </a>
            </div>

            <div
              className="footer-powered"
              onClick={() => window.open('https://telerik.com', '_blank')}
            >
              Powered by Telerik<br />
              <img
                width={16}
                src="https://telerik.com/favicon.ico"
                alt="Telerik"
                className="telerik-logo"
              />
            </div>
            <div className="footer-text-legal">
              ©1996-2026 Menphis Sistemas Inteligentes - Todos os direitos
              reservados.
            </div>
          </div>
        </div>
        <div className="login-image"></div>
      </div>
      <div id="myCustomElement"></div>
    </RecaptchaUI>
  );
};

export default AuthContainer;