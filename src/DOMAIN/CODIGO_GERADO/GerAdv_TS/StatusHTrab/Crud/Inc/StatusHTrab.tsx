"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { StatusHTrabApi } from '../../Apis/ApiStatusHTrab';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IStatusHTrabFormProps } from '../../Interfaces/interface.StatusHTrab';
import { StatusHTrabService } from '../../Services/StatusHTrab.service';
import { useStatusHTrabForm } from '../../Hooks/useStatusHTrabForm';
import { StatusHTrabEmpty } from '../../../Models/StatusHTrab'; 
import { StatusHTrabForm } from '../Forms/StatusHTrab';
 
const StatusHTrabInc: React.FC<IStatusHTrabFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const statushtrabService = new StatusHTrabService(
    new StatusHTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadStatusHTrab } = useStatusHTrabForm(
    StatusHTrabEmpty(),
    statushtrabService
  );

  useEffect(() => {
    loadStatusHTrab(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedStatusHTrab = await statushtrabService.saveStatusHTrab(data);

      if (savedStatusHTrab.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/statushtrab');
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
      <StatusHTrabForm
        statushtrabData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default StatusHTrabInc;
