"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AndCompApi } from '../../Apis/ApiAndComp';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAndCompFormProps } from '../../Interfaces/interface.AndComp';
import { AndCompService } from '../../Services/AndComp.service';
import { useAndCompForm } from '../../Hooks/useAndCompForm';
import { AndCompEmpty } from '../../../Models/AndComp'; 
import { AndCompForm } from '../Forms/AndComp';
 
const AndCompInc: React.FC<IAndCompFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const andcompService = new AndCompService(
    new AndCompApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAndComp } = useAndCompForm(
    AndCompEmpty(),
    andcompService
  );

  useEffect(() => {
    loadAndComp(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAndComp = await andcompService.saveAndComp(data);

      if (savedAndComp.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/andcomp');
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
      <AndCompForm
        andcompData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AndCompInc;
