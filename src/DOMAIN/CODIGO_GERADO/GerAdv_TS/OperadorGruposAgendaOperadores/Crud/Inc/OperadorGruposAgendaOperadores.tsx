"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadorGruposAgendaOperadoresApi } from '../../Apis/ApiOperadorGruposAgendaOperadores';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IOperadorGruposAgendaOperadoresFormProps } from '../../Interfaces/interface.OperadorGruposAgendaOperadores';
import { OperadorGruposAgendaOperadoresService } from '../../Services/OperadorGruposAgendaOperadores.service';
import { useOperadorGruposAgendaOperadoresForm } from '../../Hooks/useOperadorGruposAgendaOperadoresForm';
import { OperadorGruposAgendaOperadoresEmpty } from '../../../Models/OperadorGruposAgendaOperadores'; 
import { OperadorGruposAgendaOperadoresForm } from '../Forms/OperadorGruposAgendaOperadores';
 
const OperadorGruposAgendaOperadoresInc: React.FC<IOperadorGruposAgendaOperadoresFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const operadorgruposagendaoperadoresService = new OperadorGruposAgendaOperadoresService(
    new OperadorGruposAgendaOperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOperadorGruposAgendaOperadores } = useOperadorGruposAgendaOperadoresForm(
    OperadorGruposAgendaOperadoresEmpty(),
    operadorgruposagendaoperadoresService
  );

  useEffect(() => {
    loadOperadorGruposAgendaOperadores(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOperadorGruposAgendaOperadores = await operadorgruposagendaoperadoresService.saveOperadorGruposAgendaOperadores(data);

      if (savedOperadorGruposAgendaOperadores.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/operadorgruposagendaoperadores');
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
      <OperadorGruposAgendaOperadoresForm
        operadorgruposagendaoperadoresData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OperadorGruposAgendaOperadoresInc;
