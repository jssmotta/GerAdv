"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProSucumbenciaApi } from '../../Apis/ApiProSucumbencia';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProSucumbenciaFormProps } from '../../Interfaces/interface.ProSucumbencia';
import { ProSucumbenciaService } from '../../Services/ProSucumbencia.service';
import { useProSucumbenciaForm } from '../../Hooks/useProSucumbenciaForm';
import { ProSucumbenciaEmpty } from '../../../Models/ProSucumbencia'; 
import { ProSucumbenciaForm } from '../Forms/ProSucumbencia';
 
const ProSucumbenciaInc: React.FC<IProSucumbenciaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const prosucumbenciaService = new ProSucumbenciaService(
    new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProSucumbencia } = useProSucumbenciaForm(
    ProSucumbenciaEmpty(),
    prosucumbenciaService
  );

  useEffect(() => {
    loadProSucumbencia(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProSucumbencia = await prosucumbenciaService.saveProSucumbencia(data);

      if (savedProSucumbencia.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/prosucumbencia');
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
      <ProSucumbenciaForm
        prosucumbenciaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProSucumbenciaInc;
