"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaApi } from '../../Apis/ApiAgenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAgendaFormProps } from '../../Interfaces/interface.Agenda';
import { AgendaService } from '../../Services/Agenda.service';
import { useAgendaForm } from '../../Hooks/useAgendaForm';
import { AgendaEmpty } from '../../../Models/Agenda'; 
import { AgendaForm } from '../Forms/Agenda';
 
const AgendaInc: React.FC<IAgendaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendaService = new AgendaService(
    new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgenda } = useAgendaForm(
    AgendaEmpty(),
    agendaService
  );

  useEffect(() => {
    loadAgenda(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgenda = await agendaService.saveAgenda(data);

      if (savedAgenda.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agenda');
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
      <AgendaForm
        agendaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaInc;
