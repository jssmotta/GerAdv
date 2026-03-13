'use client';
import React, { useState, useEffect, use } from 'react';
import { Input } from '@progress/kendo-react-inputs';
import { Button } from '@progress/kendo-react-buttons';
import {
  Notification,
  NotificationGroup,
} from '@progress/kendo-react-notification';
import { Fade } from '@progress/kendo-react-animation';
import { useAppDispatch, useAppSelector } from '@/app/store/hooks';
import { selectSystemContext, selectLoginEmail } from '@/app/store/slices/systemContextSlice';
import { ChangePasswordApi, DataItem } from './api/authApi';
import { useAuth } from './AuthProvider';
import { useRouter } from 'next/navigation';
import { useSecureNavigation } from './hooks/useSecureNavigation';
import { ClearMustChangePasswordChecked } from './tools/userControl';

// Interface para as props do componente
interface ChangePasswordProps {
  onSuccess: () => void;
  onCancel?: () => void;
  readCurrentPassword: boolean;
}

const ChangePassword: React.FC<ChangePasswordProps> = ({
  onSuccess,
  onCancel,
  readCurrentPassword,
}) => {
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [localMessage, setLocalMessage] = useState<string | null>(null);
  const [messageType, setMessageType] = useState<'error' | 'info' | 'warning'>(
    'info'
  );
  const [currentPassword, setCurrentPassword] = useState('');
  const [passwordNew, setPasswordNew] = useState('');
  const [passwordConfirm, setPasswordConfirm] = useState('');
  const systemContext = useAppSelector(selectSystemContext);
  const loginEmail = useAppSelector(selectLoginEmail);
  const { logout } = useAuth();
  const router = useRouter();
  const { secureNavigate } = useSecureNavigation();

  useEffect(() => {
    if (localMessage) {
      const timer = setTimeout(() => {
        setLocalMessage(null);
      }, 5000);

      return () => clearTimeout(timer);
    }
  }, [localMessage]);

  const onError = (): void => {
    setIsSubmitting(false);
  };

  const handleSubmit = async (
    event: React.FormEvent<HTMLFormElement>
  ): Promise<void> => {
    event.preventDefault();
    
    // SEGURANÇA: Garantir que o método do form é POST
    const form = event.currentTarget;
    if (form.method && form.method.toUpperCase() !== 'POST') {
      form.method = 'post';
    }

    // SEGURANÇA: Verificar se não há dados sensíveis na URL
    if (window.location.search.includes('password') || 
        window.location.search.includes('currentPassword') ||
        window.location.search.includes('passwordNew') ||
        window.location.search.includes('passwordConfirm')) {
      console.error('🚨 SECURITY ALERT: Password data detected in URL!');
      // Limpar a URL imediatamente
      window.history.replaceState({}, document.title, window.location.pathname);
    }

    if (readCurrentPassword) {
      if (!currentPassword) {
        setLocalMessage('Senha atual é obrigatória');
        setMessageType('error');
        return;
      }
    }

    // Validar nova senha
    if (passwordNew.length < 8) {
      setLocalMessage('Nova senha deve ter pelo menos 8 caracteres');
      setMessageType('error');
      return;
    }

    // Verificar se senhas conferem
    if (passwordNew !== passwordConfirm) {
      setLocalMessage('As senhas não conferem');
      setMessageType('error');
      return;
    }

    if (readCurrentPassword) {
      if (currentPassword === passwordNew) {
        setLocalMessage('A nova senha deve ser diferente da atual');
        setMessageType('error');
        return;
      }
    }

    if (isSubmitting) return; // Evita duplo submit
    
    setIsSubmitting(true);

    const usernameToSend = systemContext?.Username || loginEmail || '';

    // SEGURANÇA: Executar a mudança de senha via HTTPS POST apenas
    await ChangePasswordApi(
      {
        email: usernameToSend,
        passwordNew: passwordNew,
        passwordConfirm: passwordConfirm,
        currentPassword: currentPassword,
      } as DataItem,
      systemContext?.TenantApp || '',
      systemContext?.Token || '',
      usernameToSend,
      readCurrentPassword,
      setLocalMessage,
      () => {
        // Mostrar mensagem local primeiro e só então executar onSuccess
        setLocalMessage('Senha alterada com sucesso!');
        setMessageType('info');
        // Limpar dados sensíveis da memória
        setCurrentPassword('');
        setPasswordNew('');
        setPasswordConfirm('');
        ClearMustChangePasswordChecked();
        // Aguarda um instante para a notificação ser visível antes de navegar
        setTimeout(() => {
          onSuccess();
        }, 900);
      },
      onError
    );

  };

  const handleCancel = (): void => {  
    setCurrentPassword('');
    setPasswordNew('');
    setPasswordConfirm('');    
    onSuccess();
    ClearMustChangePasswordChecked();
    secureNavigate('/auth', { replace: true });
  };

  useEffect(() => {
    if (localMessage?.includes("não"))
      setMessageType('error');
  }, [localMessage]);

  // SEGURANÇA: Limpar dados sensíveis quando o componente for desmontado
  useEffect(() => {
    return () => {
      setCurrentPassword('');
      setPasswordNew('');
      setPasswordConfirm('');
    };
  }, []);

  return (
    <>
      <NotificationGroup
        style={{
          position: 'absolute',
          top: '50px',
          left: '10px',
          zIndex: 1000,
        }}
      >
        {localMessage && (
          <Fade>
            <Notification
              type={{ style: messageType, icon: true }}
              closable={true}
              style={{ overflow: 'visible' }}
              onClose={() => setLocalMessage(null)}
            >
              <span>{localMessage}</span>
            </Notification>
          </Fade>
        )}
      </NotificationGroup>

      <form 
        onSubmit={handleSubmit}
        method="post"
        autoComplete="off"
        noValidate
      >
        <fieldset className={'k-form-fieldset'}>
          <legend className={'k-form-legend'}>Alterar Senha</legend>

          {readCurrentPassword && (
            <div className="mb-3">
              <Input
                className={'input-login'}
                name={'currentPassword'}
                type={'password'}
                label={'Senha atual'}
                placeholder=" "
                style={{ fontSize: '16px' }}
                value={currentPassword}
                onChange={(e) => setCurrentPassword(e.value)}
                required
              />
            </div>
          )}

          <div className="mb-3">
            <Input
              className={'input-login'}
              name={'passwordNew'}
              type={'password'}
              label={'Nova senha'}
              placeholder=" "
              style={{ fontSize: '16px' }}
              value={passwordNew}
              onChange={(e) => setPasswordNew(e.value)}
              required
            />
          </div>

          <div className="mb-3">
            <Input
              className={'input-login'}
              name={'passwordConfirm'}
              type={'password'}
              label={'Confirme a nova senha'}
              placeholder=" "
              style={{ fontSize: '16px' }}
              value={passwordConfirm}
              onChange={(e) => setPasswordConfirm(e.value)}
              required
            />
          </div>

          <div className="k-form-buttons">
            <Button
              type="submit"
              className="btnLogin dark-button-auth"
              themeColor="primary"
              disabled={isSubmitting}
            >
              {isSubmitting ? 'Pensando...' : 'Alterar senha'}
            </Button>

            <Button
              type="button"
              className="btnLogin dark-button-auth-2"
              onClick={handleCancel}
              disabled={isSubmitting}
            >
              Cancelar
            </Button>
          </div>
        </fieldset>
      </form>
    </>
  );
};

export default ChangePassword;
