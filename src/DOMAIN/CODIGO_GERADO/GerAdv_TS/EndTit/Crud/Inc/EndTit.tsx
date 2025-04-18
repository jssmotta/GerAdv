﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EndTitApi } from '../../Apis/ApiEndTit';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IEndTitFormProps } from '../../Interfaces/interface.EndTit';
import { EndTitService } from '../../Services/EndTit.service';
import { useEndTitForm } from '../../Hooks/useEndTitForm';
import { EndTitEmpty } from '../../../Models/EndTit'; 
import { EndTitForm } from '../Forms/EndTit';
 
const EndTitInc: React.FC<IEndTitFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const endtitService = new EndTitService(
    new EndTitApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEndTit } = useEndTitForm(
    EndTitEmpty(),
    endtitService
  );

  useEffect(() => {
    loadEndTit(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEndTit = await endtitService.saveEndTit(data);

      if (savedEndTit.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/endtit');
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
      <EndTitForm
        endtitData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EndTitInc;
