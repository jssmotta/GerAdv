"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessOutputRequestApi } from '../../Apis/ApiProcessOutputRequest';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProcessOutputRequestFormProps } from '../../Interfaces/interface.ProcessOutputRequest';
import { ProcessOutputRequestService } from '../../Services/ProcessOutputRequest.service';
import { useProcessOutputRequestForm } from '../../Hooks/useProcessOutputRequestForm';
import { ProcessOutputRequestEmpty } from '../../../Models/ProcessOutputRequest'; 
import { ProcessOutputRequestForm } from '../Forms/ProcessOutputRequest';
 
const ProcessOutputRequestInc: React.FC<IProcessOutputRequestFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processoutputrequestService = new ProcessOutputRequestService(
    new ProcessOutputRequestApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessOutputRequest } = useProcessOutputRequestForm(
    ProcessOutputRequestEmpty(),
    processoutputrequestService
  );

  useEffect(() => {
    loadProcessOutputRequest(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessOutputRequest = await processoutputrequestService.saveProcessOutputRequest(data);

      if (savedProcessOutputRequest.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processoutputrequest');
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
      <ProcessOutputRequestForm
        processoutputrequestData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessOutputRequestInc;
