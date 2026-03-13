'use client';
import React, { useState, useEffect } from 'react';
import { Input } from '@progress/kendo-react-inputs';
import { Button } from '@progress/kendo-react-buttons';
import {
  Notification,
  NotificationGroup,
} from '@progress/kendo-react-notification';
import { Fade } from '@progress/kendo-react-animation';

import { useAuth } from '../AuthProvider';

// Interface para as props do componente
interface CreateAccountFormProps {
  captchaSuccess: boolean;
}

const CreateAccountForm: React.FC<CreateAccountFormProps> = ({
  captchaSuccess,
}) => {
  const {
    email,    
    errorMessage,
    setEmail,
    authStatus,
    setErrorMessage,
    forceLoggedInStatus,
  } = useAuth();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [localMessage, setLocalMessage] = useState<string | null>(null);
  const [messageType, setMessageType] = useState<'error' | 'info' | 'warning'>(
    'info'
  );
  const [passwordNew, setPasswordNew] = useState('');
  const [passwordConfirm, setPasswordConfirm] = useState('');

  // Limpar a mensagem local após um tempo
  useEffect(() => {
    if (localMessage) {
      const timer = setTimeout(() => {
        setLocalMessage(null);
      }, 5000);

      return () => clearTimeout(timer);
    }
  }, [localMessage]);

  const handleSubmit = async (
    event: React.FormEvent<HTMLFormElement>
  ): Promise<void> => {
    event.preventDefault();

    if (!captchaSuccess) {
      setLocalMessage(
        'Erro de captcha. Por favor, atualize a página e tente novamente'
      );
      setMessageType('error');
      return;
    }

    // Validar senha
    if (passwordNew.length < 8) {
      setLocalMessage('Senha muito curta');
      setMessageType('error');
      return;
    }

    // Verificar se senhas conferem
    if (passwordNew !== passwordConfirm) {
      setLocalMessage('As senhas não conferem');
      setMessageType('error');
      return;
    }

    setIsSubmitting(true);
    setErrorMessage(null);

    try {
    } catch (error) {
      if (error instanceof Error) {
        setLocalMessage(error.message);
      } else {
        setLocalMessage('Ocorreu um erro ao alterar a senha');
      }
      setMessageType('error');
    } finally {
      setIsSubmitting(false);
    }
  };

  const naoSouEu = (): void => {
    setEmail(null, null);
  };

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

        {errorMessage && (
          <Fade>
            <Notification
              type={{ style: 'error', icon: true }}
              closable={true}
              style={{ overflow: 'visible' }}
              onClose={() => setErrorMessage(null)}
            >
              <span>{errorMessage}</span>
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

        <Fade>
          <Notification
            type={{ style: 'warning', icon: true }}
            closable={true}
            style={{ overflow: 'visible' }}
          >
            <span>É preciso alterar a senha!</span>
          </Notification>
        </Fade>
      </NotificationGroup>

      <form onSubmit={handleSubmit}>
        <fieldset className={'k-form-fieldset'}>
          <legend className={'k-form-legend'}></legend>

          <div className="mb-3 disabled">
            <Input
              className={'input-login'}
              name={'email'}
              type={'email'}
              label={'E-mail'}
              disabled={true}
              value={email ?? ''}
            />
          </div>

          <div className="mb-3">
            <label htmlFor="passwordNew">Nova senha</label>
            <Input
              id="passwordNew"
              className="input-login"
              name="passwordNew"
              type="password"
              value={passwordNew}
              onChange={(e) => setPasswordNew(e.value)}
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="passwordConfirm">Confirme a senha</label>
            <Input
              id="passwordConfirm"
              className="input-login"
              name="passwordConfirm"
              type="password"
              value={passwordConfirm}
              onChange={(e) => setPasswordConfirm(e.value)}
              required
            />
          </div>

          <div className="k-form-buttons">
            <Button
              type="submit"
              className="btnLogin"
              themeColor="primary"
              disabled={isSubmitting || !captchaSuccess}
            >
              {isSubmitting ? 'Pensando...' : 'Salvar nova senha'}
            </Button>
          </div>
        </fieldset>
      </form>

      <span onClick={naoSouEu} className="k-link linkNaoSouEu">
        Não sou eu!
      </span>
    </>
  );
};

export default CreateAccountForm;
