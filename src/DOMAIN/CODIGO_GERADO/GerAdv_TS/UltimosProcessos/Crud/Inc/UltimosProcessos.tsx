"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { UltimosProcessosApi } from '../../Apis/ApiUltimosProcessos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IUltimosProcessosFormProps } from '../../Interfaces/interface.UltimosProcessos';
import { UltimosProcessosService } from '../../Services/UltimosProcessos.service';
import { useUltimosProcessosForm } from '../../Hooks/useUltimosProcessosForm';
import { UltimosProcessosEmpty } from '../../../Models/UltimosProcessos'; 
import { UltimosProcessosForm } from '../Forms/UltimosProcessos';
 
const UltimosProcessosInc: React.FC<IUltimosProcessosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const ultimosprocessosService = new UltimosProcessosService(
    new UltimosProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadUltimosProcessos } = useUltimosProcessosForm(
    UltimosProcessosEmpty(),
    ultimosprocessosService
  );

  useEffect(() => {
    loadUltimosProcessos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedUltimosProcessos = await ultimosprocessosService.saveUltimosProcessos(data);

      if (savedUltimosProcessos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/ultimosprocessos');
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
      <UltimosProcessosForm
        ultimosprocessosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default UltimosProcessosInc;
