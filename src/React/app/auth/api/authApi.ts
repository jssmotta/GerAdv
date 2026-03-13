'use client';
import axios from 'axios';
import { UserModel, ValidaUserModel } from '../../models/userModel';
import { ResultApi } from '@/app/models/ResultApi';
import { decodeBase64Token, encodeBase64Token } from '../../tools/Fetcher';
import { MustChangePasswordChecked } from '@/app/auth/tools/userControl';

interface SetPasswordRequest {
  id: number;
  password: string;
}

export interface DataItem {
  email: string;
  password?: string;
  passwordNew: string;
  passwordConfirm: string;
  currentPassword?: string;
}

const apiUrl = process.env.NEXT_PUBLIC_URL_API_LOGIN;

export const RequestNewPasswordApi = async (
  dataItem: DataItem,
  tenantKey: string,
  setMessage: React.Dispatch<React.SetStateAction<string>>
) => {
  const apiUrl = process.env.NEXT_PUBLIC_URL_API_LOGIN;

  if (!apiUrl) {
    console.error('NEXT_PUBLIC_URL_API_LOGIN is not defined');
  }

  let nResult = -1;
  try {
    axios
      .post(
        `${apiUrl}/${tenantKey}/users/resetpassword`,
        {
          username: encodeBase64Token(dataItem.email),
          password: encodeBase64Token(''),
        },
        {
          headers: {
            Authorization: `Bearer ${process.env.NEXT_PUBLIC_BEARER_ENTITY}`,
          },
        }
      )
      .then((response) => {
        if (response.status === 200) {
          const envelope = response.data as ResultApi<UserModel>;
          if (!envelope.success) {
            setMessage(envelope.message || 'Erro desconhecido');
            nResult = 0;
            return;
          }
          const user = envelope.data;
          if (user.Id === 0) {
            setMessage(
              'A senha temporária será enviada em alguns instantes para o seu e-mail!'
            );
          } else {
            setMessage('Nova senha enviada para ' + dataItem.email);
          }
          // mark success so the awaiting loop can complete with true
          nResult = 1;
        } else if (response.status === 400) {
          nResult = 0;
        } else {
          nResult = 0;
        }
      })
      .catch((error) => {
        if (
          error.message === 'Network Error' ||
          error.code === 'ERR_CONNECTION_REFUSED'
        ) {
          if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
            console.log('Erro de conectividade');
          setMessage('Erro de conectividade');
        } else {
          if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
            console.log('Erro desconhecido');
          var message = error.response?.data?.message || 'Erro desconhecido';
          setMessage(message);
        }
        nResult = 0;
      });
  } catch (error: any) {
    if (
      error.message === 'Network Error' ||
      error.code === 'ERR_CONNECTION_REFUSED'
    ) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
        console.log('Erro de conectividade');
      setMessage('Erro de conectividade');
      // Adicione aqui o tratamento específico para erro de rede
    } else {
      setMessage('Verifique a sua Internet.');
    }
    nResult = 0;
  }

  while (nResult === -1) {
    await new Promise((r) => setTimeout(r, 100));
  }

  return nResult === 1;
};

export const MustChangePassword = async (user: UserModel): Promise<boolean> => {
  const apiUrl = process.env.NEXT_PUBLIC_URL_API_LOGIN;
  if (!apiUrl) {
    console.error('NEXT_PUBLIC_URL_API_LOGIN is not defined');
    return false;
  }

  const tenantKey = user.TenantApp;

  if (!user.Token) {
    console.error('User token is undefined');
    return false;
  }

  try {
    // Send username as a query param (base64 encoded) so backend can validate per-user
    const usernameParam = user.Username ? `?username=${encodeBase64Token(user.Username)}` : '';
    const response = await axios.get(`${apiUrl}/${tenantKey}/users/reset${usernameParam}`, {
      headers: {
        Authorization: `Bearer ${decodeBase64Token(user.Token)}`,
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache',
      },
    });

    if (response.status === 200) {
      const envelope = response.data as ResultApi<string>;
      if (envelope.success && (envelope.data === 'reset' || envelope.data === process.env.NEXT_PUBLIC_RESET_KEY)) {
        return true;
      }
    }
  } catch (error) {

    if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
    {
      console.log(error);
      console.log('Fail reset check');
    }
  }
  return false;
};

export const ChangePasswordApi = async (
  dataItem: DataItem,
  tenantKey: string,
  token: string,
  username: string,
  validCurrentPassword: boolean,
  setLocalMessage: any,
  onSuccess?: () => void,
  onError?: () => void
) => {
  if (dataItem.passwordNew !== dataItem.passwordConfirm) {
    return;
  }

  if (token.length === 0) {
    return;
  }
  const apiUrl = process.env.NEXT_PUBLIC_URL_API_LOGIN;
  if (!apiUrl) {
    alert('URL_API_LOGIN is not defined');
    return;
  }

  const request = {
    username: encodeBase64Token(username),
    currentPassword: encodeBase64Token(dataItem.currentPassword ?? ''),
    password: encodeBase64Token(dataItem.passwordConfirm),
    validCurrentPassword: validCurrentPassword,
  };

  try {
    const response = await axios.post(
      `${apiUrl}/${tenantKey}/users/changepassword`,
      request,
      {
        headers: {
          Authorization: `Bearer ${decodeBase64Token(token)}`,
          'Content-Type': 'application/json',
        },
      }
    );

    if (response.status === 200) {
      const envelope = response.data as ResultApi<unknown>;
      if (envelope.success) {
        if (onSuccess) onSuccess();
        setLocalMessage('Senha alterada com sucesso!');
      } else {
        if (onError) onError();
        setLocalMessage(envelope.message || 'Senha atual inválida!');
      }
    } else {
      if (onError) onError();
      setLocalMessage('Senha atual inválida!');
    }
  } catch (error: any) {
    if (onError) onError();
    setLocalMessage('Senhas não conferem ou falha de autenticação, verifique a sua Internet.');
  }
};

export const LoginValidaUsernameApi = async (
  email: string,
  tenantKey: string,
  setMessage: any
): Promise<boolean> => {
  if (!apiUrl) {
    console.error('NEXT_PUBLIC_URL_API_LOGIN is not defined');

    return false;
  }

  let nResult = -1;

  try {
  await axios
      .post(
        `${apiUrl}/${tenantKey}/users/validausername`,
        {
          username: encodeBase64Token(email),
        },
        {
          headers: {
            Authorization: `Bearer ${process.env.NEXT_PUBLIC_BEARER_ENTITY}`,
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
           'Pragma': 'no-cache',
          },
        }
      )
      .then((response) => {
        if (response.status === 200) {
          const envelope = response.data as ResultApi<ValidaUserModel>;
          if (!envelope.success) {
            if (setMessage) setMessage(envelope.message || 'Resposta inválida do servidor.');
            nResult = 0;
            return;
          }
          const user = envelope.data;
          if (user.Id === 0) {
            if (setMessage)
              setMessage('Usuário desconhecido!');
            nResult = 0;
          } else {
            nResult = 1;
          }
        } else if (response.status === 400) {
          if (setMessage)
            setMessage('Verifique a sua Internet.');
          nResult = 0;
        }
        else if (response.status === 500) {
          if (setMessage)
            setMessage('Erro no servidor: 500 - Internal Server Error');
          nResult = 0;
        }
      })
      .catch((error) => {
        // Explicitly handle unauthorized so frontend doesn't mistakenly proceed
        if (error.response?.status === 401) {
          if (setMessage) setMessage('Acesso não autorizado.');
          nResult = 0;
          return;
        }
        if (
          error.message === 'Network Error' ||
          error.code === 'ERR_CONNECTION_REFUSED'
        ) {
          if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
            console.log('Erro de conectividade');
          if (setMessage)
            setMessage('Erro de conectividade');
        } else if (error.response?.status === 500) {
          if (setMessage)
            setMessage('Erro no servidor: 500 - Internal Server Error');
        } else {
          if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
            console.log('Erro desconhecido');
          var message = error.response?.data?.message || 'Erro desconhecido';
          if (setMessage)
            setMessage(message);
        }
        nResult = 0;
      });
  } catch (error: any) {
    if (
      error.message === 'Network Error' ||
      error.code === 'ERR_CONNECTION_REFUSED'
    ) {
      console.error('Erro de conectividade: ', error);
      if (setMessage)
        setMessage('Erro de conectividade');
      // Adicione aqui o tratamento específico para erro de rede
    } else if (error.response?.status === 500) {
      if (setMessage)
        setMessage('Erro no servidor: 500 - Internal Server Error');
    } else {
      if (setMessage)
        setMessage('Verifique a sua Internet.');
    }
    nResult = 0;
  }

  while (nResult === -1) {
    await new Promise((r) => setTimeout(r, 100));
  }

  return nResult === 1;
};

const LoginApi = async (
  dataItem: DataItem,
  tenantKey: string,
  setSystemContext: React.Dispatch<React.SetStateAction<UserModel | null>>,
  wrongPassword: React.Dispatch<React.SetStateAction<boolean>>,
  setMessage: React.Dispatch<React.SetStateAction<string>>
): Promise<boolean> => {
  if (!apiUrl) {
    console.error('NEXT_PUBLIC_URL_API_LOGIN is not defined');
    return false;
  }

  const url = `${apiUrl}/${tenantKey}/users/authenticate3`; 

  try {
    const response = await axios.post(
      url,
      {
        username: encodeBase64Token(dataItem.email),
        password: encodeBase64Token(dataItem.password?.trim() ?? ''),
      },
      {
        headers: {
          Authorization: `Bearer ${process.env.NEXT_PUBLIC_BEARER_ENTITY}`,
        },
      }
    );
    
    if (response.status === 200) {
      const envelope = response.data as ResultApi<UserModel>;
      if (!envelope.success) {
        setMessage(envelope.message || 'Erro na resposta do servidor. Tente novamente.');
        wrongPassword(true);
        return false;
      }

      const user = envelope.data;
      
      if (user.Id === 0) {
        setMessage('Senha incorreta!');
        wrongPassword(true);
        return false;
      } else {
        var lMustChangePassword = await MustChangePassword(user);
       
        if (lMustChangePassword) {
          const userChange = user;
          MustChangePasswordChecked(true);
          setSystemContext(userChange);
          return true;
        } else {
          setSystemContext(user);
        }
        return true;
      }
    } else if (response.status === 400) {
      setMessage('Erro na requisição. Tente novamente.');
      wrongPassword(true);
      return false;
    }
  } catch (error: any) {
    if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
      console.log('Erro no login:', error);
    }

    // Erro de rede/conectividade
    if (
      error.message === 'Network Error' ||
      error.code === 'ERR_CONNECTION_REFUSED' ||
      error.code === 'ERR_NETWORK'
    ) {
      setMessage('Erro de conectividade. Verifique sua conexão com a Internet.');
      wrongPassword(true);
      return false;
    }

    // Tratamento baseado no código de status HTTP
    const status = error.response?.status;
    const serverMessage = error.response?.data?.message;

    switch (status) {
      case 400:
        setMessage(serverMessage || 'Erro na requisição. Tente novamente.');
        break;
      case 401:
        setMessage(serverMessage || 'Não autorizado. Verifique suas credenciais.');
        break;
      case 403:
        setMessage('Acesso negado.');
        break;
      case 404:
        setMessage('Serviço não encontrado. Contate o suporte.');
        break;
      case 500:
        setMessage('Erro interno do servidor. Tente novamente mais tarde.');
        break;
      case 503:
        setMessage(serverMessage || 'Serviço temporariamente indisponível. Tente novamente em alguns instantes.');
        break;
      case 504:
        setMessage(serverMessage || 'Tempo de conexão esgotado. Tente novamente.');
        break;
      default:
        // Usa a mensagem do servidor se disponível, senão uma mensagem genérica
        if (serverMessage) {
          setMessage(serverMessage);
        } else if (status) {
          setMessage(`Erro de autenticação (código ${status}). Tente novamente.`);
        } else {
          setMessage('Falha na autenticação. Verifique sua conexão e tente novamente.');
        }
    }
    wrongPassword(true);
  }
  return false;
};

export default LoginApi;
