"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessOutPutIDsApi } from '../../Apis/ApiProcessOutPutIDs';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProcessOutPutIDsFormProps } from '../../Interfaces/interface.ProcessOutPutIDs';
import { ProcessOutPutIDsService } from '../../Services/ProcessOutPutIDs.service';
import { useProcessOutPutIDsForm } from '../../Hooks/useProcessOutPutIDsForm';
import { ProcessOutPutIDsEmpty } from '../../../Models/ProcessOutPutIDs'; 
import { ProcessOutPutIDsForm } from '../Forms/ProcessOutPutIDs';
 
const ProcessOutPutIDsInc: React.FC<IProcessOutPutIDsFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processoutputidsService = new ProcessOutPutIDsService(
    new ProcessOutPutIDsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessOutPutIDs } = useProcessOutPutIDsForm(
    ProcessOutPutIDsEmpty(),
    processoutputidsService
  );

  useEffect(() => {
    loadProcessOutPutIDs(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessOutPutIDs = await processoutputidsService.saveProcessOutPutIDs(data);

      if (savedProcessOutPutIDs.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processoutputids');
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
      <ProcessOutPutIDsForm
        processoutputidsData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessOutPutIDsInc;
