'use client';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import React from 'react';
import ErrorMessage from '../Cruds/ErrorMessage';

import { useAppDispatch } from '@/app/store/hooks';
import { setLoginEmail, setSystemContext } from '@/app/store/slices/systemContextSlice';
import { useAuth } from '@/app/auth/AuthProvider';
import { CONTROL_OPTIONS } from '@/app/GerAdv/Menu/DrawerControl';

const ErrorNotificationHandler: React.FC = () => {
  const [errorMessage, setErrorMessage] = React.useState<string | null>(null);
  const [notificationType, setNotificationType] = React.useState<NotifySystemActions | null>(null);
  const [clickMenu, setClickMenu] = React.useState(0);
  const dispatch = useAppDispatch();
  const { logout } = useAuth();
  
  React.useEffect(() => {
    if (clickMenu === CONTROL_OPTIONS.LOGOUT) {        
        dispatch(setLoginEmail(null));
        dispatch(setSystemContext(null));
        logout();        
        if (typeof window !== 'undefined') {
            window.location.replace('/auth');
        }
    }
  }, [clickMenu]);

  React.useEffect(() => {
    const unsubscribe = subscribeToNotifications('*', (entity) => {
      try {

        var error404 = entity.message?.includes('404') ?? false;
        
        if (error404) {
          setClickMenu(CONTROL_OPTIONS.LOGOUT);          
        }

        if (entity.action === NotifySystemActions.ERROR) {
          setNotificationType(NotifySystemActions.ERROR);
          let cMessage = entity.message || 'Um erro ocorreu.';

          if (cMessage.includes('Network Error')) {
            cMessage = 'Ocorreu um erro de rede. Verifique conexão com a Internet.';
          }

          setErrorMessage(cMessage ?? 'Erro desconhecido.');
        } else if (entity.action === NotifySystemActions.INFO) {
          setNotificationType(NotifySystemActions.INFO);
          setErrorMessage(entity.message ?? '');
        }
      } catch (error) {
        console.error('Error processing notification:', error);
      }
    });

    return () => {
      unsubscribe();
    };
  }, []);  

  return (
    <ErrorMessage
      notificationType={notificationType}
      mensagem={errorMessage}
      setErrorMessage={setErrorMessage}
    />
  );
};

export default ErrorNotificationHandler;

