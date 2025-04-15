"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EscritoriosApi } from '../../Apis/ApiEscritorios';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IEscritoriosFormProps } from '../../Interfaces/interface.Escritorios';
import { EscritoriosService } from '../../Services/Escritorios.service';
import { useEscritoriosForm } from '../../Hooks/useEscritoriosForm';
import { EscritoriosEmpty } from '../../../Models/Escritorios'; 
import { EscritoriosForm } from '../Forms/Escritorios';
 
const EscritoriosInc: React.FC<IEscritoriosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const escritoriosService = new EscritoriosService(
    new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEscritorios } = useEscritoriosForm(
    EscritoriosEmpty(),
    escritoriosService
  );

  useEffect(() => {
    loadEscritorios(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEscritorios = await escritoriosService.saveEscritorios(data);

      if (savedEscritorios.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/escritorios');
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
      <EscritoriosForm
        escritoriosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EscritoriosInc;
