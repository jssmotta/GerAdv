﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AtividadesApi } from '../../Apis/ApiAtividades';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAtividadesFormProps } from '../../Interfaces/interface.Atividades';
import { AtividadesService } from '../../Services/Atividades.service';
import { useAtividadesForm } from '../../Hooks/useAtividadesForm';
import { AtividadesEmpty } from '../../../Models/Atividades'; 
import { AtividadesForm } from '../Forms/Atividades';
 
const AtividadesInc: React.FC<IAtividadesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const atividadesService = new AtividadesService(
    new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAtividades } = useAtividadesForm(
    AtividadesEmpty(),
    atividadesService
  );

  useEffect(() => {
    loadAtividades(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAtividades = await atividadesService.saveAtividades(data);

      if (savedAtividades.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/atividades');
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
      <AtividadesForm
        atividadesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AtividadesInc;
