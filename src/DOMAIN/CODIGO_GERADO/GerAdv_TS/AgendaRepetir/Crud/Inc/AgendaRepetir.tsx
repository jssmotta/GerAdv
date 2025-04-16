"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaRepetirApi } from '../../Apis/ApiAgendaRepetir';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAgendaRepetirFormProps } from '../../Interfaces/interface.AgendaRepetir';
import { AgendaRepetirService } from '../../Services/AgendaRepetir.service';
import { useAgendaRepetirForm } from '../../Hooks/useAgendaRepetirForm';
import { AgendaRepetirEmpty } from '../../../Models/AgendaRepetir'; 
import { AgendaRepetirForm } from '../Forms/AgendaRepetir';
 
const AgendaRepetirInc: React.FC<IAgendaRepetirFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendarepetirService = new AgendaRepetirService(
    new AgendaRepetirApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgendaRepetir } = useAgendaRepetirForm(
    AgendaRepetirEmpty(),
    agendarepetirService
  );

  useEffect(() => {
    loadAgendaRepetir(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgendaRepetir = await agendarepetirService.saveAgendaRepetir(data);

      if (savedAgendaRepetir.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agendarepetir');
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
      <AgendaRepetirForm
        agendarepetirData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaRepetirInc;
