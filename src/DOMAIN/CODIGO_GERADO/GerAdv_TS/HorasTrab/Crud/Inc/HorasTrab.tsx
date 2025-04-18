﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { HorasTrabApi } from '../../Apis/ApiHorasTrab';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IHorasTrabFormProps } from '../../Interfaces/interface.HorasTrab';
import { HorasTrabService } from '../../Services/HorasTrab.service';
import { useHorasTrabForm } from '../../Hooks/useHorasTrabForm';
import { HorasTrabEmpty } from '../../../Models/HorasTrab'; 
import { HorasTrabForm } from '../Forms/HorasTrab';
 
const HorasTrabInc: React.FC<IHorasTrabFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const horastrabService = new HorasTrabService(
    new HorasTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadHorasTrab } = useHorasTrabForm(
    HorasTrabEmpty(),
    horastrabService
  );

  useEffect(() => {
    loadHorasTrab(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedHorasTrab = await horastrabService.saveHorasTrab(data);

      if (savedHorasTrab.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/horastrab');
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
      <HorasTrabForm
        horastrabData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default HorasTrabInc;
