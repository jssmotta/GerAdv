﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GUTTipoApi } from '../../Apis/ApiGUTTipo';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IGUTTipoFormProps } from '../../Interfaces/interface.GUTTipo';
import { GUTTipoService } from '../../Services/GUTTipo.service';
import { useGUTTipoForm } from '../../Hooks/useGUTTipoForm';
import { GUTTipoEmpty } from '../../../Models/GUTTipo'; 
import { GUTTipoForm } from '../Forms/GUTTipo';
 
const GUTTipoInc: React.FC<IGUTTipoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const guttipoService = new GUTTipoService(
    new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGUTTipo } = useGUTTipoForm(
    GUTTipoEmpty(),
    guttipoService
  );

  useEffect(() => {
    loadGUTTipo(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGUTTipo = await guttipoService.saveGUTTipo(data);

      if (savedGUTTipo.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/guttipo');
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
      <GUTTipoForm
        guttipoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GUTTipoInc;
