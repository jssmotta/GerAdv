"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GUTAtividadesApi } from '../../Apis/ApiGUTAtividades';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IGUTAtividadesFormProps } from '../../Interfaces/interface.GUTAtividades';
import { GUTAtividadesService } from '../../Services/GUTAtividades.service';
import { useGUTAtividadesForm } from '../../Hooks/useGUTAtividadesForm';
import { GUTAtividadesEmpty } from '../../../Models/GUTAtividades'; 
import { GUTAtividadesForm } from '../Forms/GUTAtividades';
 
const GUTAtividadesInc: React.FC<IGUTAtividadesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gutatividadesService = new GUTAtividadesService(
    new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGUTAtividades } = useGUTAtividadesForm(
    GUTAtividadesEmpty(),
    gutatividadesService
  );

  useEffect(() => {
    loadGUTAtividades(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGUTAtividades = await gutatividadesService.saveGUTAtividades(data);

      if (savedGUTAtividades.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gutatividades');
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
      <GUTAtividadesForm
        gutatividadesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GUTAtividadesInc;
