"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProValoresApi } from '../../Apis/ApiProValores';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IProValoresFormProps } from '../../Interfaces/interface.ProValores';
import { ProValoresService } from '../../Services/ProValores.service';
import { useProValoresForm } from '../../Hooks/useProValoresForm';
import { ProValoresEmpty } from '../../../Models/ProValores'; 
import { ProValoresForm } from '../Forms/ProValores';
 
const ProValoresInc: React.FC<IProValoresFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const provaloresService = new ProValoresService(
    new ProValoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProValores } = useProValoresForm(
    ProValoresEmpty(),
    provaloresService
  );

  useEffect(() => {
    loadProValores(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProValores = await provaloresService.saveProValores(data);

      if (savedProValores.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/provalores');
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
      <ProValoresForm
        provaloresData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProValoresInc;
