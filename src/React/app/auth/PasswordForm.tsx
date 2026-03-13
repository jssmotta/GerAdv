'use client';
import React, { useState, useEffect, use } from 'react';
import { useRouter } from 'next/navigation'; // Importar o router
import { useAuth, AuthStatus } from './AuthProvider';
import { Button } from '@progress/kendo-react-buttons';
import {
  Notification,
  NotificationGroup,
} from '@progress/kendo-react-notification';
import { Fade } from '@progress/kendo-react-animation';
import { Input } from '@progress/kendo-react-inputs'; 
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { selectSystemContext, setSystemContext } from '../store/slices/systemContextSlice';
import { MustChangePasswordChecked } from '@/app/auth/tools/userControl';
// Interface para as props do componente
interface PasswordFormProps {
  captchaSuccess: boolean;
}

const PasswordForm: React.FC<PasswordFormProps> = ({ captchaSuccess }) => {
  const {
    email,
    tenant,
    login,
    requestPasswordReset,
    errorMessage,
    setTenant,
    setEmail,
    logout,
    changeStatus, 
  } = useAuth();
  const dispatch = useAppDispatch();
  const systemContext = useAppSelector(selectSystemContext);
  const router = useRouter(); // Usar o router para redirecionamento direto
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [isResetting, setIsResetting] = useState(false);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);
  const [password, setPassword] = useState<string>('');
  const [passwordError, setPasswordError] = useState<string>('');
  const [isRedirecting, setIsRedirecting] = useState(false);
  const [waitReset, setWaitReset] = useState(false);
  const [showResetDialog, setShowResetDialog] = useState(false);

  useEffect(() => {
    setIsSubmitting(false);
  }, [isResetting, errorMessage]);
  // Limpar mensagens de sucesso após um tempo
  useEffect(() => {
    if (successMessage) {
      const timer = setTimeout(() => {
        setSuccessMessage(null);
      }, 5000);

      return () => clearTimeout(timer);
    }
  }, [successMessage]);

  useEffect(() => {
    if (tenant === null) {
      logout();
      setEmail(null, null);
    }
  }, [tenant]);

  // Verificar localStorage  para determinar se já houve uma tentativa de login bem-sucedida
  useEffect(() => {
    const loginSuccessFlag = localStorage.getItem(
      btoa(`${process.env.NEXT_PUBLIC_APP_GLOBAL}login_success`)
    );
    if (loginSuccessFlag === 'true' && !isRedirecting) {
      setIsRedirecting(true);
      localStorage.removeItem(
        btoa(`${process.env.NEXT_PUBLIC_APP_GLOBAL}login_success`)
      );
      router.push('/auth/splash');
    }
  }, [router, isRedirecting]);

  const handleSubmit = async (
    event: React.FormEvent<HTMLFormElement>
  ): Promise<void> => {
    event.preventDefault();

    if (!captchaSuccess) {
      setPasswordError('Erro no ReCaptcha. Por favor, tente novamente.');
      return;
    }

    if (!password && !isResetting) {
      setPasswordError('Campo obrigatório');
      return;
    }

    const localWaitReset = waitReset;
    setWaitReset(false);
    setIsSubmitting(true);

    if (isResetting) {
      await requestPasswordReset(tenant ?? '');
      setSuccessMessage('Solicitação de nova senha enviada');
      setIsResetting(false);
      setWaitReset(true);
    } else {
      try {
        const loginSuccess = await login(tenant ?? '', password);

        if (loginSuccess) {
          setSuccessMessage('Login realizado com sucesso! Redirecionando...');
          setIsRedirecting(true);
          setTimeout(() => {
            if (MustChangePasswordChecked()) {
              localStorage.setItem(
                btoa(`${process.env.NEXT_PUBLIC_APP_GLOBAL}cp`),
                'true'
              );
              changeStatus(AuthStatus.PASSWORD_RESET_REQUIRED);
           
              router.push('/auth/cp'); // AQUI
            } else {
              localStorage.setItem(
                btoa(`${process.env.NEXT_PUBLIC_APP_GLOBAL}login_success`),
                'true'
              );
              router.push('/auth/splash');
            }
          }, 800);
        }
      } catch (error) {}
    }
  };

  const naoSouEu = (): void => {
    setEmail(null, null);
  };

  const enviarNovaSenha = (): void => {
    setShowResetDialog(true);
  };

  const handleConfirmReset = async (): Promise<void> => {  
    setShowResetDialog(false);
     await requestPasswordReset(tenant ?? '');
      setSuccessMessage('Solicitação de nova senha enviada');
      setIsResetting(false);
      setWaitReset(true);
      setPassword('');
      setPasswordError('');
  };

  const handleCancelReset = (): void => {
    setShowResetDialog(false);
  };

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

  return (
    <>
      <style>
        {`
        .show-footer-2 {
          display: block;
         }
           input {
        width: 80vw !important;
        max-width: 390px !important;
      }
      `}
      </style>
      {/* NotificationGroup para mensagens */}
      <NotificationGroup
        style={{
          position: 'absolute',
          top: '50px',
          left: '10px',
          zIndex: 1000,
        }}
      >
        {errorMessage && (
          <Fade>
            <Notification
              type={{ style: 'error', icon: true }}
              closable={true}
              style={{ overflow: 'visible' }}
            >
              <span>{errorMessage}</span>
            </Notification>
          </Fade>
        )}

        {successMessage && (
          <Fade>
            <Notification
              type={{ style: 'info', icon: true }}
              closable={true}
              style={{ overflow: 'visible' }}
            >
              <span>{successMessage}</span>
            </Notification>
          </Fade>
        )}

        {!captchaSuccess && (
          <Fade>
            <Notification type={{ style: 'error', icon: true }} closable={true}>
              Limpe o cache do seu browser e tente novamente. Erro ReCaptcha.
            </Notification>
          </Fade>
        )} 
      </NotificationGroup>

      <form onSubmit={handleSubmit} className="k-form">
        <fieldset className="k-form-fieldset">
          <div className="form-group">
            <Input
              className="input-login"
              name="email"
              type="email"
              label="E-mail"
              style={{ fontSize: '16px' }}
              disabled={true}
              value={email ?? ''}
              placeholder="E-mail"
            />
          </div>

          {!isResetting && (
            <div className="form-group">
              <Input
                className="input-login"
                name="password"
                type="password"
                label="Senha"
                value={password}
                required={true}
                onChange={(e) => {
                  setPassword(e.value);
                  setPasswordError('');
                }}
                placeholder="Senha"
              />
              {passwordError && <span className="error">{passwordError}</span>}
            </div>
          )}

          <div className="k-form-buttons button-continue">
            <Button
              type="submit"
              themeColor="primary"
              className="btnLogin dark-button-auth" 
              disabled={((password == null || password.length == 0) && !isResetting) || isSubmitting || !captchaSuccess || isRedirecting}
            >
              {isRedirecting
                ? 'Redirecionando...'
                : isSubmitting
                  ? 'Pensando...'
                  : isResetting
                    ? 'Solicitar nova senha'
                    : 'ENTRAR'}
            </Button>

            {!waitReset && !isResetting && errorMessage && !isRedirecting && (
              <Button
                type="button"
                className="btnLogin dark-button-auth-2"
                onClick={() => {
                  setIsResetting(true);
                  setPassword('');
                  setPasswordError('');
                }}
              >
                Resetar senha...
              </Button>
            )}

            {isResetting && !isRedirecting && (
              <Button
                type="button"
                className="btnLogin dark-button-auth-2"
                onClick={() => {
                  onSuccess()
                }}
              >
                VOLTAR
              </Button>
            )}
          </div>
        </fieldset>

        {!isRedirecting && (
          <>
          {tenant && (
           <span onClick={naoSouEu} title='Saia dessa conta e entre com a sua' className="linkNaoSouEu">
              Não é {tenant}!
            </span>)}
            <span onClick={naoSouEu} title='Saia dessa conta e entre com a sua' className="linkNaoSouEu">
              Não sou eu!
            </span>
            <span onClick={enviarNovaSenha} title='Solicitar reset de senha' className="linkNaoSouEu">
              Resetar senha
            </span>
          </>
        )}
      </form>

      {showResetDialog && (
        <Dialog title="Confirmar Reset de Senha" onClose={handleCancelReset}>
          <p style={{ margin: '25px', textAlign: 'center' }}>
            Deseja realmente solicitar o reset de senha para o e-mail <strong>{email}</strong>?
          </p>
          <DialogActionsBar>
            <Button onClick={handleCancelReset}>Cancelar</Button>
            <Button themeColor="primary" onClick={handleConfirmReset}>
              Confirmar
            </Button>
          </DialogActionsBar>
        </Dialog>
      )}
    </>
  );
};

export default PasswordForm;
 
