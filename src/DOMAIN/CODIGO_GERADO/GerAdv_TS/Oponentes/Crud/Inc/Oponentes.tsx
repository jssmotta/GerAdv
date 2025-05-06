"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OponentesApi } from '../../Apis/ApiOponentes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IOponentesFormProps } from '../../Interfaces/interface.Oponentes';
import { OponentesService } from '../../Services/Oponentes.service';
import { useOponentesForm } from '../../Hooks/useOponentesForm';
import { OponentesEmpty } from '../../../Models/Oponentes'; 
import { OponentesForm } from '../Forms/Oponentes';
 
const OponentesInc: React.FC<IOponentesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const oponentesService = new OponentesService(
    new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOponentes } = useOponentesForm(
    OponentesEmpty(),
    oponentesService
  );

  useEffect(() => {
    loadOponentes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOponentes = await oponentesService.saveOponentes(data);

      if (savedOponentes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/oponentes');
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
      <OponentesForm
        oponentesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OponentesInc;
