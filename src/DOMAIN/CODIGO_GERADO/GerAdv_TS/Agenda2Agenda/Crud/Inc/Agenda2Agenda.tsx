"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { Agenda2AgendaApi } from '../../Apis/ApiAgenda2Agenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAgenda2AgendaFormProps } from '../../Interfaces/interface.Agenda2Agenda';
import { Agenda2AgendaService } from '../../Services/Agenda2Agenda.service';
import { useAgenda2AgendaForm } from '../../Hooks/useAgenda2AgendaForm';
import { Agenda2AgendaEmpty } from '../../../Models/Agenda2Agenda'; 
import { Agenda2AgendaForm } from '../Forms/Agenda2Agenda';
 
const Agenda2AgendaInc: React.FC<IAgenda2AgendaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agenda2agendaService = new Agenda2AgendaService(
    new Agenda2AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgenda2Agenda } = useAgenda2AgendaForm(
    Agenda2AgendaEmpty(),
    agenda2agendaService
  );

  useEffect(() => {
    loadAgenda2Agenda(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgenda2Agenda = await agenda2agendaService.saveAgenda2Agenda(data);

      if (savedAgenda2Agenda.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agenda2agenda');
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
      <Agenda2AgendaForm
        agenda2agendaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default Agenda2AgendaInc;
