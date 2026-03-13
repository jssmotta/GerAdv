// services/AuthServiceAdapter.ts
import { UserModel } from '../models/userModel';
import LoginApi, {
  LoginValidaUsernameApi,
  RequestNewPasswordApi,
} from './api/authApi';

// Definição clara de estados para autenticação
export enum AuthStatus {
  LOGGED_OUT = 'LOGGED_OUT',
  VALIDATING_USERNAME = 'VALIDATING_USERNAME',
  VALIDATING_PASSWORD = 'VALIDATING_PASSWORD',
  PASSWORD_RESET_REQUIRED = 'PASSWORD_RESET_REQUIRED',
  CHANGING_PASSWORD = 'CHANGING_PASSWORD',
  CREATE_ACCPOUNT = 'CREATE_ACCOUNT',
  LOGGED_IN = 'LOGGED_IN',
}

// Definição clara de estados para captcha
export enum CaptchaStatus {
  WAITING = 0,
  VERIFIED = 1,
  FAILED = 2,
}

// Interface para credenciais de login
export interface AuthCredentials {
  email: string;
  password: string;
}

// Interface para solicitação de alteração de senha
export interface PasswordChangeRequest {
  email: string;
  passwordNew: string;
  passwordConfirm: string;
}

// Interface para o adaptador do serviço de autenticação
export interface IAuthServiceAdapter {
  validateUsername(
    email: string,
    tenantKey: string,
    setMessage: React.Dispatch<React.SetStateAction<string | null>>
  ): Promise<boolean>;
  login(
    credentials: AuthCredentials,
    tenantKey: string,
    setSystemContext: React.Dispatch<React.SetStateAction<UserModel | null>>,
    setwrongPassword: React.Dispatch<React.SetStateAction<boolean>>,
    setMessage: React.Dispatch<React.SetStateAction<string | null>>
  ): Promise<boolean>;
  requestPasswordReset(
    email: string,
    tenantKey: string,
    setMessage: React.Dispatch<React.SetStateAction<string | null>>
  ): Promise<void>;
}

// Implementação do adaptador que usa a API de login existente
export class AuthServiceAdapter implements IAuthServiceAdapter {
  async validateUsername(
    email: string,
    tenantKey: string,
    setMessage: any
  ): Promise<boolean> {
    return await LoginValidaUsernameApi(email, tenantKey, setMessage);
  }

  async login(
    credentials: AuthCredentials,
    tenantKey: string,
    setSystemContext: React.Dispatch<React.SetStateAction<UserModel | null>>,
    setwrongPassword: React.Dispatch<React.SetStateAction<boolean>>,
    setMessage: any
  ): Promise<boolean> {
    const dataItem = {
      email: credentials.email,
      password: credentials.password,
      passwordNew: '',
      passwordConfirm: '',
    };

    try {
      return await LoginApi(
        dataItem,
        tenantKey,
        setSystemContext,
        setwrongPassword,
        setMessage
      );
    } catch (error) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1')
        console.log('Erro durante o login');
      return false;
    }
  }


  async requestPasswordReset(
    email: string,
    tenantKey: string,
    setMessage: any
  ): Promise<void> {
    const dataItem = {
      email: email,
      password: '',
      passwordNew: '',
      passwordConfirm: '',
    };

    await RequestNewPasswordApi(dataItem, tenantKey, setMessage);
  }
}

// Instância singleton do adaptador para uso em toda a aplicação
export const authServiceAdapter = new AuthServiceAdapter();
