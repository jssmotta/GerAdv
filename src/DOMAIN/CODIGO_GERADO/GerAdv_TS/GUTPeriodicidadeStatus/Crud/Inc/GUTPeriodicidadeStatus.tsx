"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GUTPeriodicidadeStatusApi } from '../../Apis/ApiGUTPeriodicidadeStatus';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IGUTPeriodicidadeStatusFormProps } from '../../Interfaces/interface.GUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusService } from '../../Services/GUTPeriodicidadeStatus.service';
import { useGUTPeriodicidadeStatusForm } from '../../Hooks/useGUTPeriodicidadeStatusForm';
import { GUTPeriodicidadeStatusEmpty } from '../../../Models/GUTPeriodicidadeStatus'; 
import { GUTPeriodicidadeStatusForm } from '../Forms/GUTPeriodicidadeStatus';
 
const GUTPeriodicidadeStatusInc: React.FC<IGUTPeriodicidadeStatusFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gutperiodicidadestatusService = new GUTPeriodicidadeStatusService(
    new GUTPeriodicidadeStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGUTPeriodicidadeStatus } = useGUTPeriodicidadeStatusForm(
    GUTPeriodicidadeStatusEmpty(),
    gutperiodicidadestatusService
  );

  useEffect(() => {
    loadGUTPeriodicidadeStatus(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGUTPeriodicidadeStatus = await gutperiodicidadestatusService.saveGUTPeriodicidadeStatus(data);

      if (savedGUTPeriodicidadeStatus.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gutperiodicidadestatus');
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
      <GUTPeriodicidadeStatusForm
        gutperiodicidadestatusData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GUTPeriodicidadeStatusInc;
