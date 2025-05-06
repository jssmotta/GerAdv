"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PrepostosApi } from '../../Apis/ApiPrepostos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IPrepostosFormProps } from '../../Interfaces/interface.Prepostos';
import { PrepostosService } from '../../Services/Prepostos.service';
import { usePrepostosForm } from '../../Hooks/usePrepostosForm';
import { PrepostosEmpty } from '../../../Models/Prepostos'; 
import { PrepostosForm } from '../Forms/Prepostos';
 
const PrepostosInc: React.FC<IPrepostosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const prepostosService = new PrepostosService(
    new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPrepostos } = usePrepostosForm(
    PrepostosEmpty(),
    prepostosService
  );

  useEffect(() => {
    loadPrepostos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPrepostos = await prepostosService.savePrepostos(data);

      if (savedPrepostos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/prepostos');
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
      <PrepostosForm
        prepostosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PrepostosInc;
