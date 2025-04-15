"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadorApi } from '../../Apis/ApiOperador';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IOperadorFormProps } from '../../Interfaces/interface.Operador';
import { OperadorService } from '../../Services/Operador.service';
import { useOperadorForm } from '../../Hooks/useOperadorForm';
import { OperadorEmpty } from '../../../Models/Operador'; 
import { OperadorForm } from '../Forms/Operador';
 
const OperadorInc: React.FC<IOperadorFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const operadorService = new OperadorService(
    new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOperador } = useOperadorForm(
    OperadorEmpty(),
    operadorService
  );

  useEffect(() => {
    loadOperador(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOperador = await operadorService.saveOperador(data);

      if (savedOperador.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/operador');
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
      <OperadorForm
        operadorData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OperadorInc;
