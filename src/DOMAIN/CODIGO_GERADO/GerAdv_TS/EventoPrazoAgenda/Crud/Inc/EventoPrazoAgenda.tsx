"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EventoPrazoAgendaApi } from '../../Apis/ApiEventoPrazoAgenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IEventoPrazoAgendaFormProps } from '../../Interfaces/interface.EventoPrazoAgenda';
import { EventoPrazoAgendaService } from '../../Services/EventoPrazoAgenda.service';
import { useEventoPrazoAgendaForm } from '../../Hooks/useEventoPrazoAgendaForm';
import { EventoPrazoAgendaEmpty } from '../../../Models/EventoPrazoAgenda'; 
import { EventoPrazoAgendaForm } from '../Forms/EventoPrazoAgenda';
 
const EventoPrazoAgendaInc: React.FC<IEventoPrazoAgendaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const eventoprazoagendaService = new EventoPrazoAgendaService(
    new EventoPrazoAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEventoPrazoAgenda } = useEventoPrazoAgendaForm(
    EventoPrazoAgendaEmpty(),
    eventoprazoagendaService
  );

  useEffect(() => {
    loadEventoPrazoAgenda(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEventoPrazoAgenda = await eventoprazoagendaService.saveEventoPrazoAgenda(data);

      if (savedEventoPrazoAgenda.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/eventoprazoagenda');
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
      <EventoPrazoAgendaForm
        eventoprazoagendaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EventoPrazoAgendaInc;
