"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { StatusAndamentoApi } from '../../Apis/ApiStatusAndamento';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IStatusAndamentoFormProps } from '../../Interfaces/interface.StatusAndamento';
import { StatusAndamentoService } from '../../Services/StatusAndamento.service';
import { useStatusAndamentoForm } from '../../Hooks/useStatusAndamentoForm';
import { StatusAndamentoEmpty } from '../../../Models/StatusAndamento'; 
import { StatusAndamentoForm } from '../Forms/StatusAndamento';
 
const StatusAndamentoInc: React.FC<IStatusAndamentoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const statusandamentoService = new StatusAndamentoService(
    new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadStatusAndamento } = useStatusAndamentoForm(
    StatusAndamentoEmpty(),
    statusandamentoService
  );

  useEffect(() => {
    loadStatusAndamento(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedStatusAndamento = await statusandamentoService.saveStatusAndamento(data);

      if (savedStatusAndamento.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/statusandamento');
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
      <StatusAndamentoForm
        statusandamentoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default StatusAndamentoInc;
