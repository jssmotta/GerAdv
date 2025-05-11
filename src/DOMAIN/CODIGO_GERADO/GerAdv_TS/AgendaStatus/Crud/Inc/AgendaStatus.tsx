"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaStatusApi } from '../../Apis/ApiAgendaStatus';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAgendaStatusFormProps } from '../../Interfaces/interface.AgendaStatus';
import { AgendaStatusService } from '../../Services/AgendaStatus.service';
import { useAgendaStatusForm } from '../../Hooks/useAgendaStatusForm';
import { AgendaStatusEmpty } from '../../../Models/AgendaStatus'; 
import { AgendaStatusForm } from '../Forms/AgendaStatus';
 
const AgendaStatusInc: React.FC<IAgendaStatusFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendastatusService = new AgendaStatusService(
    new AgendaStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgendaStatus } = useAgendaStatusForm(
    AgendaStatusEmpty(),
    agendastatusService
  );

  useEffect(() => {
    loadAgendaStatus(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgendaStatus = await agendastatusService.saveAgendaStatus(data);

      if (savedAgendaStatus.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agendastatus');
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
      <AgendaStatusForm
        agendastatusData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaStatusInc;
