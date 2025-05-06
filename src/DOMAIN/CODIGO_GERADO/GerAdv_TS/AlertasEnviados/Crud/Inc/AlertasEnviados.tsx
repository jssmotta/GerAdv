"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AlertasEnviadosApi } from '../../Apis/ApiAlertasEnviados';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAlertasEnviadosFormProps } from '../../Interfaces/interface.AlertasEnviados';
import { AlertasEnviadosService } from '../../Services/AlertasEnviados.service';
import { useAlertasEnviadosForm } from '../../Hooks/useAlertasEnviadosForm';
import { AlertasEnviadosEmpty } from '../../../Models/AlertasEnviados'; 
import { AlertasEnviadosForm } from '../Forms/AlertasEnviados';
 
const AlertasEnviadosInc: React.FC<IAlertasEnviadosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const alertasenviadosService = new AlertasEnviadosService(
    new AlertasEnviadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAlertasEnviados } = useAlertasEnviadosForm(
    AlertasEnviadosEmpty(),
    alertasenviadosService
  );

  useEffect(() => {
    loadAlertasEnviados(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAlertasEnviados = await alertasenviadosService.saveAlertasEnviados(data);

      if (savedAlertasEnviados.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/alertasenviados');
          return;
        }

        if (onSuccess) {
          onSuccess();
        }
      } else {
         if (onError) {
          onError();
        }
        notificationService.showNotification('Error salvando registro.', 'error');
      }
    } catch (error) {
        if (onError) {
          onError();
        }
      notificationService.showNotification('Error salvando registro.', 'error');
    }
  };

  return (
    <>
      <NotificationComponent notificationService={notificationService} />
      <AlertasEnviadosForm
        alertasenviadosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AlertasEnviadosInc;
