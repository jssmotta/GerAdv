"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProCDAApi } from '../../Apis/ApiProCDA';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProCDAFormProps } from '../../Interfaces/interface.ProCDA';
import { ProCDAService } from '../../Services/ProCDA.service';
import { useProCDAForm } from '../../Hooks/useProCDAForm';
import { ProCDAEmpty } from '../../../Models/ProCDA'; 
import { ProCDAForm } from '../Forms/ProCDA';
 
const ProCDAInc: React.FC<IProCDAFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const procdaService = new ProCDAService(
    new ProCDAApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProCDA } = useProCDAForm(
    ProCDAEmpty(),
    procdaService
  );

  useEffect(() => {
    loadProCDA(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProCDA = await procdaService.saveProCDA(data);

      if (savedProCDA.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/procda');
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
      <ProCDAForm
        procdaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProCDAInc;
