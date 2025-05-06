"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessOutputEngineApi } from '../../Apis/ApiProcessOutputEngine';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IProcessOutputEngineFormProps } from '../../Interfaces/interface.ProcessOutputEngine';
import { ProcessOutputEngineService } from '../../Services/ProcessOutputEngine.service';
import { useProcessOutputEngineForm } from '../../Hooks/useProcessOutputEngineForm';
import { ProcessOutputEngineEmpty } from '../../../Models/ProcessOutputEngine'; 
import { ProcessOutputEngineForm } from '../Forms/ProcessOutputEngine';
 
const ProcessOutputEngineInc: React.FC<IProcessOutputEngineFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processoutputengineService = new ProcessOutputEngineService(
    new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessOutputEngine } = useProcessOutputEngineForm(
    ProcessOutputEngineEmpty(),
    processoutputengineService
  );

  useEffect(() => {
    loadProcessOutputEngine(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessOutputEngine = await processoutputengineService.saveProcessOutputEngine(data);

      if (savedProcessOutputEngine.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processoutputengine');
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
      <ProcessOutputEngineForm
        processoutputengineData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessOutputEngineInc;
