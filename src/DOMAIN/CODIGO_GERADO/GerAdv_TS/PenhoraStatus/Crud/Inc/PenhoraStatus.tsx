﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PenhoraStatusApi } from '../../Apis/ApiPenhoraStatus';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IPenhoraStatusFormProps } from '../../Interfaces/interface.PenhoraStatus';
import { PenhoraStatusService } from '../../Services/PenhoraStatus.service';
import { usePenhoraStatusForm } from '../../Hooks/usePenhoraStatusForm';
import { PenhoraStatusEmpty } from '../../../Models/PenhoraStatus'; 
import { PenhoraStatusForm } from '../Forms/PenhoraStatus';
 
const PenhoraStatusInc: React.FC<IPenhoraStatusFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const penhorastatusService = new PenhoraStatusService(
    new PenhoraStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPenhoraStatus } = usePenhoraStatusForm(
    PenhoraStatusEmpty(),
    penhorastatusService
  );

  useEffect(() => {
    loadPenhoraStatus(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPenhoraStatus = await penhorastatusService.savePenhoraStatus(data);

      if (savedPenhoraStatus.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/penhorastatus');
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
      <PenhoraStatusForm
        penhorastatusData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PenhoraStatusInc;
