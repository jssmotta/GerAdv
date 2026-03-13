'use client';
import React, { useEffect, useState } from 'react';
import { Form, Field, FormElement } from '@progress/kendo-react-form';
import { Input as KendoInput } from '@progress/kendo-react-inputs';
import { Button } from '@progress/kendo-react-buttons';
import { useAuth } from './AuthProvider';
import {
  Notification,
  NotificationGroup,
} from '@progress/kendo-react-notification';
import { Fade } from '@progress/kendo-react-animation';
import { useRouter } from 'next/navigation'; 
// Interface para as props do componente
interface UsernameFormProps {
  onSuccess?: () => void;
}

// Validação de email
const emailValidator = (value: string): string | undefined => {
  if (!value) {
    return 'Campo obrigatório';
  }

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailRegex.test(value)) {
    return 'Email inválido';
  }

  return undefined; // Return undefined for valid inputs
};

const UsernameForm: React.FC<UsernameFormProps> = ({ onSuccess }) => {
  const { validateUsername, errorMessage, setErrorMessage } = useAuth();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const router = useRouter();

  useEffect(() => {
    localStorage.removeItem(
      btoa(`${process.env.NEXT_PUBLIC_APP_GLOBAL}login_success`)
    );
  }, []);

  const handleSubmit = async (values: {
    [name: string]: any;
  }): Promise<void> => {
    setIsSubmitting(true);
    setErrorMessage(null);
    try {
      const success = await validateUsername(values.dominio, values.email);
      if (success && onSuccess) {
        onSuccess();
      }
    } catch (error) {
      setErrorMessage('Ocorreu um erro ao validar o e-mail.');
    } finally {
      setIsSubmitting(false);
    }
  };

  const UppercaseInput = (fieldProps: any) => (
    <KendoInput
      {...fieldProps}
      value={fieldProps.value ? fieldProps.value.toUpperCase() : ''}
      onChange={(e) => {
        fieldProps.onChange({
          value: e.value.toUpperCase(),
          syntheticEvent: e.syntheticEvent,
        });
      }}
    />
  );

  const LowercaseInput = (fieldProps: any) => (
    <KendoInput
      {...fieldProps}
      value={fieldProps.value ? fieldProps.value.toLowerCase() : ''}
      onChange={(e) => {
        fieldProps.onChange({
          value: e.value.toLowerCase(),
          syntheticEvent: e.syntheticEvent,
        });
      }}
    />
  );

  const cadastrese = () => {
    router.push('/auth/createaccount');
    router.refresh();
  };

  return (
    <>
      <style>
        {`
        .show-footer {
          display: block;
        }         
        input {
          width: 100% !important;
          max-width: 400px !important;
          height: 56px !important;
          padding: 16px 20px !important;
          font-size: 16px !important;
        }
     
      `}
      </style>
      {errorMessage && (
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
        </NotificationGroup>
      )}
      <div className="login-top1"></div>
      <Form
        onSubmit={handleSubmit}
        render={(formRenderProps) => (
          <FormElement>
            <fieldset className={'k-form-fieldset'}>
              <div className="mb-3">
                <Field
                  className={'input-login'}
                  name={'dominio'}
                  required={true}
                  component={UppercaseInput}
                  type={'string'}
                  fontSize={'16px'}
                  placeholder={'Informe o domínio'}
                  label={'Domínio'}     
                  autoComplete="on"             
                />
              </div>
              <div className="mb-3">
                <Field
                  className={'input-login'}
                  name={'email'}
                  component={LowercaseInput}
                  type={'email'}
                  fontSize={'16px'}
                  label={'E-mail'}
                  placeholder={'Informe o seu e-mail'}
                  validator={emailValidator}
                  required={true}
                  autoComplete="on"             
                />
              </div>

              <div className="k-form-buttons button-continue button-username-continuar">
                <Button
                  type={'submit'}
                  themeColor="primary"
                  className="btnLogin"
                  disabled={isSubmitting || !formRenderProps.valid}
                >
                  {isSubmitting ? 'Pensando...' : 'Continuar'}
                </Button>
              </div>
            </fieldset>
          </FormElement>
        )}
      />

      {process.env.NEXT_PUBLIC_CADASTRESE === 'true' && (
        <div className="login-cadastrese">
          <p>
            Não tem uma conta?{' '}
            <span onClick={cadastrese} className="link-cadastro">
              Cadastre-se
            </span>
          </p>
        </div>
      )}
    </>
  );
};

export default UsernameForm;
