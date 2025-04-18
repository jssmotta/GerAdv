﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessosApi } from '../../Apis/ApiProcessos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProcessosFormProps } from '../../Interfaces/interface.Processos';
import { ProcessosService } from '../../Services/Processos.service';
import { useProcessosForm } from '../../Hooks/useProcessosForm';
import { ProcessosEmpty } from '../../../Models/Processos'; 
import { ProcessosForm } from '../Forms/Processos';
 
const ProcessosInc: React.FC<IProcessosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processosService = new ProcessosService(
    new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessos } = useProcessosForm(
    ProcessosEmpty(),
    processosService
  );

  useEffect(() => {
    loadProcessos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessos = await processosService.saveProcessos(data);

      if (savedProcessos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processos');
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
      <ProcessosForm
        processosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessosInc;
