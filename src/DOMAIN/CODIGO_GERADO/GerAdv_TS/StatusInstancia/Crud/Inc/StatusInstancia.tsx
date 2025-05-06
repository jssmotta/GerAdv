"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { StatusInstanciaApi } from '../../Apis/ApiStatusInstancia';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IStatusInstanciaFormProps } from '../../Interfaces/interface.StatusInstancia';
import { StatusInstanciaService } from '../../Services/StatusInstancia.service';
import { useStatusInstanciaForm } from '../../Hooks/useStatusInstanciaForm';
import { StatusInstanciaEmpty } from '../../../Models/StatusInstancia'; 
import { StatusInstanciaForm } from '../Forms/StatusInstancia';
 
const StatusInstanciaInc: React.FC<IStatusInstanciaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const statusinstanciaService = new StatusInstanciaService(
    new StatusInstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadStatusInstancia } = useStatusInstanciaForm(
    StatusInstanciaEmpty(),
    statusinstanciaService
  );

  useEffect(() => {
    loadStatusInstancia(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedStatusInstancia = await statusinstanciaService.saveStatusInstancia(data);

      if (savedStatusInstancia.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/statusinstancia');
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
      <StatusInstanciaForm
        statusinstanciaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default StatusInstanciaInc;
