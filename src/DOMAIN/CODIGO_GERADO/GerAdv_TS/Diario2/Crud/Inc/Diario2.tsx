﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { Diario2Api } from '../../Apis/ApiDiario2';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IDiario2FormProps } from '../../Interfaces/interface.Diario2';
import { Diario2Service } from '../../Services/Diario2.service';
import { useDiario2Form } from '../../Hooks/useDiario2Form';
import { Diario2Empty } from '../../../Models/Diario2'; 
import { Diario2Form } from '../Forms/Diario2';
 
const Diario2Inc: React.FC<IDiario2FormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const diario2Service = new Diario2Service(
    new Diario2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadDiario2 } = useDiario2Form(
    Diario2Empty(),
    diario2Service
  );

  useEffect(() => {
    loadDiario2(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedDiario2 = await diario2Service.saveDiario2(data);

      if (savedDiario2.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/diario2');
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
      <Diario2Form
        diario2Data={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default Diario2Inc;
