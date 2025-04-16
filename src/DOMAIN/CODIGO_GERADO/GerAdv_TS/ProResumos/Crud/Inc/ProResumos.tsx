"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProResumosApi } from '../../Apis/ApiProResumos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProResumosFormProps } from '../../Interfaces/interface.ProResumos';
import { ProResumosService } from '../../Services/ProResumos.service';
import { useProResumosForm } from '../../Hooks/useProResumosForm';
import { ProResumosEmpty } from '../../../Models/ProResumos'; 
import { ProResumosForm } from '../Forms/ProResumos';
 
const ProResumosInc: React.FC<IProResumosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const proresumosService = new ProResumosService(
    new ProResumosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProResumos } = useProResumosForm(
    ProResumosEmpty(),
    proresumosService
  );

  useEffect(() => {
    loadProResumos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProResumos = await proresumosService.saveProResumos(data);

      if (savedProResumos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/proresumos');
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
      <ProResumosForm
        proresumosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProResumosInc;
