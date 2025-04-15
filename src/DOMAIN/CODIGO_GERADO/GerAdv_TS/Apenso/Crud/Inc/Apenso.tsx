"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ApensoApi } from '../../Apis/ApiApenso';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IApensoFormProps } from '../../Interfaces/interface.Apenso';
import { ApensoService } from '../../Services/Apenso.service';
import { useApensoForm } from '../../Hooks/useApensoForm';
import { ApensoEmpty } from '../../../Models/Apenso'; 
import { ApensoForm } from '../Forms/Apenso';
 
const ApensoInc: React.FC<IApensoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const apensoService = new ApensoService(
    new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadApenso } = useApensoForm(
    ApensoEmpty(),
    apensoService
  );

  useEffect(() => {
    loadApenso(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedApenso = await apensoService.saveApenso(data);

      if (savedApenso.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/apenso');
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
      <ApensoForm
        apensoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ApensoInc;
