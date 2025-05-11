"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { JusticaApi } from '../../Apis/ApiJustica';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IJusticaFormProps } from '../../Interfaces/interface.Justica';
import { JusticaService } from '../../Services/Justica.service';
import { useJusticaForm } from '../../Hooks/useJusticaForm';
import { JusticaEmpty } from '../../../Models/Justica'; 
import { JusticaForm } from '../Forms/Justica';
 
const JusticaInc: React.FC<IJusticaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const justicaService = new JusticaService(
    new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadJustica } = useJusticaForm(
    JusticaEmpty(),
    justicaService
  );

  useEffect(() => {
    loadJustica(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedJustica = await justicaService.saveJustica(data);

      if (savedJustica.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/justica');
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
      <JusticaForm
        justicaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default JusticaInc;
