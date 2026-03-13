'use client';
import React, { useEffect, useRef } from 'react';

import { useAppDispatch, useAppSelector } from '../store/hooks';
import { selectSystemContext, selectLoginEmail, setSystemContext, setLoginEmail } from '../store/slices/systemContextSlice';
import { useAuth } from './AuthProvider';

/**
 * Componente que serve como ponte entre o novo contexto de autenticação
 * e o contexto de sistema existente.
 *
 * Versão atualizada para prevenir loops de atualização de estado.
 */
const AuthSystemBridge: React.FC<{ children: React.ReactNode }> = ({
  children,
}) => {
  const { user, email } = useAuth();

  const dispatch = useAppDispatch();
  const systemContext = useAppSelector(selectSystemContext);
  const loginEmail = useAppSelector(selectLoginEmail);

  // Refs para armazenar valores anteriores
  const prevUserRef = useRef(user);
  const prevEmailRef = useRef(email);

  // Sincronizar o estado de usuário entre os contextos
  useEffect(() => {
    // Só atualiza se o valor realmente mudou e é diferente do SystemContext
    if (
      JSON.stringify(user) !== JSON.stringify(prevUserRef.current) &&
      JSON.stringify(user) !== JSON.stringify(systemContext)
    ) {
      dispatch(setSystemContext(user));
      prevUserRef.current = user;
    }
  }, [user, dispatch, systemContext]);

  // Sincronizar o email entre os contextos
  useEffect(() => {
    // Só atualiza se o valor realmente mudou e é diferente do loginEmail atual
    if (email !== prevEmailRef.current && email !== loginEmail) {
      dispatch(setLoginEmail(email));
      prevEmailRef.current = email;
    }
  }, [email, dispatch, loginEmail]);

  // Simplesmente renderiza os filhos
  return <>{children}</>;
};

export default AuthSystemBridge;
