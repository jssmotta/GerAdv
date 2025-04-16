"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TerceirosApi } from '../../Apis/ApiTerceiros';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITerceirosFormProps } from '../../Interfaces/interface.Terceiros';
import { TerceirosService } from '../../Services/Terceiros.service';
import { useTerceirosForm } from '../../Hooks/useTerceirosForm';
import { TerceirosEmpty } from '../../../Models/Terceiros'; 
import { TerceirosForm } from '../Forms/Terceiros';
 
const TerceirosInc: React.FC<ITerceirosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const terceirosService = new TerceirosService(
    new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTerceiros } = useTerceirosForm(
    TerceirosEmpty(),
    terceirosService
  );

  useEffect(() => {
    loadTerceiros(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTerceiros = await terceirosService.saveTerceiros(data);

      if (savedTerceiros.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/terceiros');
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
      <TerceirosForm
        terceirosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TerceirosInc;
