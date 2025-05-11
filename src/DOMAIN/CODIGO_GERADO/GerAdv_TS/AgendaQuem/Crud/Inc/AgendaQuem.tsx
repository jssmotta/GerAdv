"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaQuemApi } from '../../Apis/ApiAgendaQuem';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAgendaQuemFormProps } from '../../Interfaces/interface.AgendaQuem';
import { AgendaQuemService } from '../../Services/AgendaQuem.service';
import { useAgendaQuemForm } from '../../Hooks/useAgendaQuemForm';
import { AgendaQuemEmpty } from '../../../Models/AgendaQuem'; 
import { AgendaQuemForm } from '../Forms/AgendaQuem';
 
const AgendaQuemInc: React.FC<IAgendaQuemFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendaquemService = new AgendaQuemService(
    new AgendaQuemApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgendaQuem } = useAgendaQuemForm(
    AgendaQuemEmpty(),
    agendaquemService
  );

  useEffect(() => {
    loadAgendaQuem(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgendaQuem = await agendaquemService.saveAgendaQuem(data);

      if (savedAgendaQuem.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agendaquem');
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
      <AgendaQuemForm
        agendaquemData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaQuemInc;
