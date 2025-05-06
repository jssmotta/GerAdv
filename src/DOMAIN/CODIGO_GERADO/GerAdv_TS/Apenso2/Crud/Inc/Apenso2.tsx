"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { Apenso2Api } from '../../Apis/ApiApenso2';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IApenso2FormProps } from '../../Interfaces/interface.Apenso2';
import { Apenso2Service } from '../../Services/Apenso2.service';
import { useApenso2Form } from '../../Hooks/useApenso2Form';
import { Apenso2Empty } from '../../../Models/Apenso2'; 
import { Apenso2Form } from '../Forms/Apenso2';
 
const Apenso2Inc: React.FC<IApenso2FormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const apenso2Service = new Apenso2Service(
    new Apenso2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadApenso2 } = useApenso2Form(
    Apenso2Empty(),
    apenso2Service
  );

  useEffect(() => {
    loadApenso2(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedApenso2 = await apenso2Service.saveApenso2(data);

      if (savedApenso2.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/apenso2');
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
      <Apenso2Form
        apenso2Data={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default Apenso2Inc;
