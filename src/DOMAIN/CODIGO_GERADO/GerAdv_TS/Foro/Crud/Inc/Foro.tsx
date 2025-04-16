"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ForoApi } from '../../Apis/ApiForo';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IForoFormProps } from '../../Interfaces/interface.Foro';
import { ForoService } from '../../Services/Foro.service';
import { useForoForm } from '../../Hooks/useForoForm';
import { ForoEmpty } from '../../../Models/Foro'; 
import { ForoForm } from '../Forms/Foro';
 
const ForoInc: React.FC<IForoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const foroService = new ForoService(
    new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadForo } = useForoForm(
    ForoEmpty(),
    foroService
  );

  useEffect(() => {
    loadForo(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedForo = await foroService.saveForo(data);

      if (savedForo.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/foro');
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
      <ForoForm
        foroData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ForoInc;
