﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ReuniaoApi } from '../../Apis/ApiReuniao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IReuniaoFormProps } from '../../Interfaces/interface.Reuniao';
import { ReuniaoService } from '../../Services/Reuniao.service';
import { useReuniaoForm } from '../../Hooks/useReuniaoForm';
import { ReuniaoEmpty } from '../../../Models/Reuniao'; 
import { ReuniaoForm } from '../Forms/Reuniao';
 
const ReuniaoInc: React.FC<IReuniaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const reuniaoService = new ReuniaoService(
    new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadReuniao } = useReuniaoForm(
    ReuniaoEmpty(),
    reuniaoService
  );

  useEffect(() => {
    loadReuniao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedReuniao = await reuniaoService.saveReuniao(data);

      if (savedReuniao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/reuniao');
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
      <ReuniaoForm
        reuniaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ReuniaoInc;
