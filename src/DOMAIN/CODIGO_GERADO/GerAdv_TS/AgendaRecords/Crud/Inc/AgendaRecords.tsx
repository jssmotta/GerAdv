"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaRecordsApi } from '../../Apis/ApiAgendaRecords';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAgendaRecordsFormProps } from '../../Interfaces/interface.AgendaRecords';
import { AgendaRecordsService } from '../../Services/AgendaRecords.service';
import { useAgendaRecordsForm } from '../../Hooks/useAgendaRecordsForm';
import { AgendaRecordsEmpty } from '../../../Models/AgendaRecords'; 
import { AgendaRecordsForm } from '../Forms/AgendaRecords';
 
const AgendaRecordsInc: React.FC<IAgendaRecordsFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendarecordsService = new AgendaRecordsService(
    new AgendaRecordsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgendaRecords } = useAgendaRecordsForm(
    AgendaRecordsEmpty(),
    agendarecordsService
  );

  useEffect(() => {
    loadAgendaRecords(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgendaRecords = await agendarecordsService.saveAgendaRecords(data);

      if (savedAgendaRecords.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agendarecords');
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
      <AgendaRecordsForm
        agendarecordsData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaRecordsInc;
