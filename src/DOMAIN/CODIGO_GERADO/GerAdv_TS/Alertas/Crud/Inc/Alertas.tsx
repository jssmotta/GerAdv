﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AlertasApi } from '../../Apis/ApiAlertas';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAlertasFormProps } from '../../Interfaces/interface.Alertas';
import { AlertasService } from '../../Services/Alertas.service';
import { useAlertasForm } from '../../Hooks/useAlertasForm';
import { AlertasEmpty } from '../../../Models/Alertas'; 
import { AlertasForm } from '../Forms/Alertas';
 
const AlertasInc: React.FC<IAlertasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const alertasService = new AlertasService(
    new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAlertas } = useAlertasForm(
    AlertasEmpty(),
    alertasService
  );

  useEffect(() => {
    loadAlertas(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAlertas = await alertasService.saveAlertas(data);

      if (savedAlertas.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/alertas');
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
      <AlertasForm
        alertasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AlertasInc;
