"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GUTMatrizApi } from '../../Apis/ApiGUTMatriz';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IGUTMatrizFormProps } from '../../Interfaces/interface.GUTMatriz';
import { GUTMatrizService } from '../../Services/GUTMatriz.service';
import { useGUTMatrizForm } from '../../Hooks/useGUTMatrizForm';
import { GUTMatrizEmpty } from '../../../Models/GUTMatriz'; 
import { GUTMatrizForm } from '../Forms/GUTMatriz';
 
const GUTMatrizInc: React.FC<IGUTMatrizFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gutmatrizService = new GUTMatrizService(
    new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGUTMatriz } = useGUTMatrizForm(
    GUTMatrizEmpty(),
    gutmatrizService
  );

  useEffect(() => {
    loadGUTMatriz(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGUTMatriz = await gutmatrizService.saveGUTMatriz(data);

      if (savedGUTMatriz.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gutmatriz');
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
      <GUTMatrizForm
        gutmatrizData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GUTMatrizInc;
