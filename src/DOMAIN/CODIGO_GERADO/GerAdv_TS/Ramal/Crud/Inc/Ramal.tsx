"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { RamalApi } from '../../Apis/ApiRamal';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IRamalFormProps } from '../../Interfaces/interface.Ramal';
import { RamalService } from '../../Services/Ramal.service';
import { useRamalForm } from '../../Hooks/useRamalForm';
import { RamalEmpty } from '../../../Models/Ramal'; 
import { RamalForm } from '../Forms/Ramal';
 
const RamalInc: React.FC<IRamalFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const ramalService = new RamalService(
    new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadRamal } = useRamalForm(
    RamalEmpty(),
    ramalService
  );

  useEffect(() => {
    loadRamal(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedRamal = await ramalService.saveRamal(data);

      if (savedRamal.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/ramal');
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
      <RamalForm
        ramalData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default RamalInc;
