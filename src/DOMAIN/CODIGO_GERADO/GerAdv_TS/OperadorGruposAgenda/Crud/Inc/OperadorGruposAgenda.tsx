"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadorGruposAgendaApi } from '../../Apis/ApiOperadorGruposAgenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IOperadorGruposAgendaFormProps } from '../../Interfaces/interface.OperadorGruposAgenda';
import { OperadorGruposAgendaService } from '../../Services/OperadorGruposAgenda.service';
import { useOperadorGruposAgendaForm } from '../../Hooks/useOperadorGruposAgendaForm';
import { OperadorGruposAgendaEmpty } from '../../../Models/OperadorGruposAgenda'; 
import { OperadorGruposAgendaForm } from '../Forms/OperadorGruposAgenda';
 
const OperadorGruposAgendaInc: React.FC<IOperadorGruposAgendaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const operadorgruposagendaService = new OperadorGruposAgendaService(
    new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOperadorGruposAgenda } = useOperadorGruposAgendaForm(
    OperadorGruposAgendaEmpty(),
    operadorgruposagendaService
  );

  useEffect(() => {
    loadOperadorGruposAgenda(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOperadorGruposAgenda = await operadorgruposagendaService.saveOperadorGruposAgenda(data);

      if (savedOperadorGruposAgenda.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/operadorgruposagenda');
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
      <OperadorGruposAgendaForm
        operadorgruposagendaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OperadorGruposAgendaInc;
