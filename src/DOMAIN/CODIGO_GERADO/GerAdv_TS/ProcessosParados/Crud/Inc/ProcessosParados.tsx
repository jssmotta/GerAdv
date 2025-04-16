"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessosParadosApi } from '../../Apis/ApiProcessosParados';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProcessosParadosFormProps } from '../../Interfaces/interface.ProcessosParados';
import { ProcessosParadosService } from '../../Services/ProcessosParados.service';
import { useProcessosParadosForm } from '../../Hooks/useProcessosParadosForm';
import { ProcessosParadosEmpty } from '../../../Models/ProcessosParados'; 
import { ProcessosParadosForm } from '../Forms/ProcessosParados';
 
const ProcessosParadosInc: React.FC<IProcessosParadosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processosparadosService = new ProcessosParadosService(
    new ProcessosParadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessosParados } = useProcessosParadosForm(
    ProcessosParadosEmpty(),
    processosparadosService
  );

  useEffect(() => {
    loadProcessosParados(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessosParados = await processosparadosService.saveProcessosParados(data);

      if (savedProcessosParados.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processosparados');
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
      <ProcessosParadosForm
        processosparadosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessosParadosInc;
