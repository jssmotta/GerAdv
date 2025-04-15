"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GUTAtividadesMatrizApi } from '../../Apis/ApiGUTAtividadesMatriz';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IGUTAtividadesMatrizFormProps } from '../../Interfaces/interface.GUTAtividadesMatriz';
import { GUTAtividadesMatrizService } from '../../Services/GUTAtividadesMatriz.service';
import { useGUTAtividadesMatrizForm } from '../../Hooks/useGUTAtividadesMatrizForm';
import { GUTAtividadesMatrizEmpty } from '../../../Models/GUTAtividadesMatriz'; 
import { GUTAtividadesMatrizForm } from '../Forms/GUTAtividadesMatriz';
 
const GUTAtividadesMatrizInc: React.FC<IGUTAtividadesMatrizFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gutatividadesmatrizService = new GUTAtividadesMatrizService(
    new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGUTAtividadesMatriz } = useGUTAtividadesMatrizForm(
    GUTAtividadesMatrizEmpty(),
    gutatividadesmatrizService
  );

  useEffect(() => {
    loadGUTAtividadesMatriz(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGUTAtividadesMatriz = await gutatividadesmatrizService.saveGUTAtividadesMatriz(data);

      if (savedGUTAtividadesMatriz.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gutatividadesmatriz');
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
      <GUTAtividadesMatrizForm
        gutatividadesmatrizData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GUTAtividadesMatrizInc;
