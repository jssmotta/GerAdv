"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PreClientesApi } from '../../Apis/ApiPreClientes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IPreClientesFormProps } from '../../Interfaces/interface.PreClientes';
import { PreClientesService } from '../../Services/PreClientes.service';
import { usePreClientesForm } from '../../Hooks/usePreClientesForm';
import { PreClientesEmpty } from '../../../Models/PreClientes'; 
import { PreClientesForm } from '../Forms/PreClientes';
 
const PreClientesInc: React.FC<IPreClientesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const preclientesService = new PreClientesService(
    new PreClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPreClientes } = usePreClientesForm(
    PreClientesEmpty(),
    preclientesService
  );

  useEffect(() => {
    loadPreClientes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPreClientes = await preclientesService.savePreClientes(data);

      if (savedPreClientes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/preclientes');
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
      <PreClientesForm
        preclientesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PreClientesInc;
