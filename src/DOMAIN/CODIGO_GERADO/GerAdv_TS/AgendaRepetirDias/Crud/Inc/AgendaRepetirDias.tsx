"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaRepetirDiasApi } from '../../Apis/ApiAgendaRepetirDias';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAgendaRepetirDiasFormProps } from '../../Interfaces/interface.AgendaRepetirDias';
import { AgendaRepetirDiasService } from '../../Services/AgendaRepetirDias.service';
import { useAgendaRepetirDiasForm } from '../../Hooks/useAgendaRepetirDiasForm';
import { AgendaRepetirDiasEmpty } from '../../../Models/AgendaRepetirDias'; 
import { AgendaRepetirDiasForm } from '../Forms/AgendaRepetirDias';
 
const AgendaRepetirDiasInc: React.FC<IAgendaRepetirDiasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendarepetirdiasService = new AgendaRepetirDiasService(
    new AgendaRepetirDiasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgendaRepetirDias } = useAgendaRepetirDiasForm(
    AgendaRepetirDiasEmpty(),
    agendarepetirdiasService
  );

  useEffect(() => {
    loadAgendaRepetirDias(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgendaRepetirDias = await agendarepetirdiasService.saveAgendaRepetirDias(data);

      if (savedAgendaRepetirDias.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agendarepetirdias');
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
      <AgendaRepetirDiasForm
        agendarepetirdiasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaRepetirDiasInc;
