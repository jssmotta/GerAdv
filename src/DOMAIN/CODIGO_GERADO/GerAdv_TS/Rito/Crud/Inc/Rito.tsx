﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { RitoApi } from '../../Apis/ApiRito';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IRitoFormProps } from '../../Interfaces/interface.Rito';
import { RitoService } from '../../Services/Rito.service';
import { useRitoForm } from '../../Hooks/useRitoForm';
import { RitoEmpty } from '../../../Models/Rito'; 
import { RitoForm } from '../Forms/Rito';
 
const RitoInc: React.FC<IRitoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const ritoService = new RitoService(
    new RitoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadRito } = useRitoForm(
    RitoEmpty(),
    ritoService
  );

  useEffect(() => {
    loadRito(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedRito = await ritoService.saveRito(data);

      if (savedRito.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/rito');
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
      <RitoForm
        ritoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default RitoInc;
