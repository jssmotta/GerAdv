"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PaisesApi } from '../../Apis/ApiPaises';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IPaisesFormProps } from '../../Interfaces/interface.Paises';
import { PaisesService } from '../../Services/Paises.service';
import { usePaisesForm } from '../../Hooks/usePaisesForm';
import { PaisesEmpty } from '../../../Models/Paises'; 
import { PaisesForm } from '../Forms/Paises';
 
const PaisesInc: React.FC<IPaisesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const paisesService = new PaisesService(
    new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPaises } = usePaisesForm(
    PaisesEmpty(),
    paisesService
  );

  useEffect(() => {
    loadPaises(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPaises = await paisesService.savePaises(data);

      if (savedPaises.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/paises');
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
      <PaisesForm
        paisesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PaisesInc;
