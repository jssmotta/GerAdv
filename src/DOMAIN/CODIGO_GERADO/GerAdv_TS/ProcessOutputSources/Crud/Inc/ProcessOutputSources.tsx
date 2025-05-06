"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessOutputSourcesApi } from '../../Apis/ApiProcessOutputSources';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IProcessOutputSourcesFormProps } from '../../Interfaces/interface.ProcessOutputSources';
import { ProcessOutputSourcesService } from '../../Services/ProcessOutputSources.service';
import { useProcessOutputSourcesForm } from '../../Hooks/useProcessOutputSourcesForm';
import { ProcessOutputSourcesEmpty } from '../../../Models/ProcessOutputSources'; 
import { ProcessOutputSourcesForm } from '../Forms/ProcessOutputSources';
 
const ProcessOutputSourcesInc: React.FC<IProcessOutputSourcesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processoutputsourcesService = new ProcessOutputSourcesService(
    new ProcessOutputSourcesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessOutputSources } = useProcessOutputSourcesForm(
    ProcessOutputSourcesEmpty(),
    processoutputsourcesService
  );

  useEffect(() => {
    loadProcessOutputSources(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessOutputSources = await processoutputsourcesService.saveProcessOutputSources(data);

      if (savedProcessOutputSources.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processoutputsources');
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
      <ProcessOutputSourcesForm
        processoutputsourcesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessOutputSourcesInc;
