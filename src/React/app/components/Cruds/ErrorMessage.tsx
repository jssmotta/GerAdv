import React, { useEffect } from 'react';
import {
  Notification,
  NotificationGroup,
} from '@progress/kendo-react-notification';
import { NotifySystemActions } from '../../tools/NotifySystem';
import { useIsMobile } from '@/app/context/MobileContext';
interface ErrorMessageProps {
  mensagem: string | null;
  setErrorMessage: (msg: string | null) => void;
  notificationType?: NotifySystemActions | null;
}

const ErrorMessage: React.FC<ErrorMessageProps> = ({
  mensagem,
  setErrorMessage,
  notificationType,
}) => {
  useEffect(() => {
    if (mensagem) {
      const timer = setTimeout(() => setErrorMessage(null), 5000);
      return () => clearTimeout(timer);
    }
  }, [mensagem, setErrorMessage]);

  const isMobile = useIsMobile();

  if (!mensagem) return null;

  return (
    <NotificationGroup
      style={isMobile ? {
        position: 'absolute',
        bottom: 0,
        right: '1vw',
        width: '100vw',
        zIndex: 999999999,
        pointerEvents: 'none',
        display: 'block',
      }
        :
        {
          position: 'absolute',
          right: '1vw',
          top: '1vh',
          zIndex: 999999999,
          pointerEvents: 'none',
          display: 'block',
          margin: '0 auto',
          width: 'auto',
        }}
    >
      <Notification
        type={{
          style:
            notificationType === NotifySystemActions.INFO && !mensagem.includes("off-line") ? 'info' : 'error',
          icon: true,
        }}
        closable={true}
        onClose={() => setErrorMessage(null)}
        style={{
          marginLeft: 0,
          maxWidth: 800,
          width: 'auto',
          pointerEvents: 'auto',
          fontSize: '16px',
          textAlign: 'center',
        }}
      >
        {mensagem}
      </Notification>
    </NotificationGroup>
  );
};

export default ErrorMessage;
