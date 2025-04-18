﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { BensMateriaisApi } from '../../Apis/ApiBensMateriais';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IBensMateriaisFormProps } from '../../Interfaces/interface.BensMateriais';
import { BensMateriaisService } from '../../Services/BensMateriais.service';
import { useBensMateriaisForm } from '../../Hooks/useBensMateriaisForm';
import { BensMateriaisEmpty } from '../../../Models/BensMateriais'; 
import { BensMateriaisForm } from '../Forms/BensMateriais';
 
const BensMateriaisInc: React.FC<IBensMateriaisFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const bensmateriaisService = new BensMateriaisService(
    new BensMateriaisApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadBensMateriais } = useBensMateriaisForm(
    BensMateriaisEmpty(),
    bensmateriaisService
  );

  useEffect(() => {
    loadBensMateriais(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedBensMateriais = await bensmateriaisService.saveBensMateriais(data);

      if (savedBensMateriais.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/bensmateriais');
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
      <BensMateriaisForm
        bensmateriaisData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default BensMateriaisInc;
