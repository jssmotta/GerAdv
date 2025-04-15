"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PenhoraApi } from '../../Apis/ApiPenhora';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IPenhoraFormProps } from '../../Interfaces/interface.Penhora';
import { PenhoraService } from '../../Services/Penhora.service';
import { usePenhoraForm } from '../../Hooks/usePenhoraForm';
import { PenhoraEmpty } from '../../../Models/Penhora'; 
import { PenhoraForm } from '../Forms/Penhora';
 
const PenhoraInc: React.FC<IPenhoraFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const penhoraService = new PenhoraService(
    new PenhoraApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPenhora } = usePenhoraForm(
    PenhoraEmpty(),
    penhoraService
  );

  useEffect(() => {
    loadPenhora(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPenhora = await penhoraService.savePenhora(data);

      if (savedPenhora.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/penhora');
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
      <PenhoraForm
        penhoraData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PenhoraInc;
