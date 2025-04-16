"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { StatusTarefasApi } from '../../Apis/ApiStatusTarefas';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IStatusTarefasFormProps } from '../../Interfaces/interface.StatusTarefas';
import { StatusTarefasService } from '../../Services/StatusTarefas.service';
import { useStatusTarefasForm } from '../../Hooks/useStatusTarefasForm';
import { StatusTarefasEmpty } from '../../../Models/StatusTarefas'; 
import { StatusTarefasForm } from '../Forms/StatusTarefas';
 
const StatusTarefasInc: React.FC<IStatusTarefasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const statustarefasService = new StatusTarefasService(
    new StatusTarefasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadStatusTarefas } = useStatusTarefasForm(
    StatusTarefasEmpty(),
    statustarefasService
  );

  useEffect(() => {
    loadStatusTarefas(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedStatusTarefas = await statustarefasService.saveStatusTarefas(data);

      if (savedStatusTarefas.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/statustarefas');
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
      <StatusTarefasForm
        statustarefasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default StatusTarefasInc;
