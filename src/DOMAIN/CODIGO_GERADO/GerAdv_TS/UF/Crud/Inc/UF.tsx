"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { UFApi } from '../../Apis/ApiUF';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IUFFormProps } from '../../Interfaces/interface.UF';
import { UFService } from '../../Services/UF.service';
import { useUFForm } from '../../Hooks/useUFForm';
import { UFEmpty } from '../../../Models/UF'; 
import { UFForm } from '../Forms/UF';
 
const UFInc: React.FC<IUFFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const ufService = new UFService(
    new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadUF } = useUFForm(
    UFEmpty(),
    ufService
  );

  useEffect(() => {
    loadUF(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedUF = await ufService.saveUF(data);

      if (savedUF.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/uf');
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
      <UFForm
        ufData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default UFInc;
