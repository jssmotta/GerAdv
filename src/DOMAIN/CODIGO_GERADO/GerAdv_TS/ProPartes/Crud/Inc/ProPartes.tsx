"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProPartesApi } from '../../Apis/ApiProPartes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProPartesFormProps } from '../../Interfaces/interface.ProPartes';
import { ProPartesService } from '../../Services/ProPartes.service';
import { useProPartesForm } from '../../Hooks/useProPartesForm';
import { ProPartesEmpty } from '../../../Models/ProPartes'; 
import { ProPartesForm } from '../Forms/ProPartes';
 
const ProPartesInc: React.FC<IProPartesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const propartesService = new ProPartesService(
    new ProPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProPartes } = useProPartesForm(
    ProPartesEmpty(),
    propartesService
  );

  useEffect(() => {
    loadProPartes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProPartes = await propartesService.saveProPartes(data);

      if (savedProPartes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/propartes');
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
      <ProPartesForm
        propartesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProPartesInc;
