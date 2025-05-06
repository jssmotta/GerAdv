"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ServicosApi } from '../../Apis/ApiServicos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IServicosFormProps } from '../../Interfaces/interface.Servicos';
import { ServicosService } from '../../Services/Servicos.service';
import { useServicosForm } from '../../Hooks/useServicosForm';
import { ServicosEmpty } from '../../../Models/Servicos'; 
import { ServicosForm } from '../Forms/Servicos';
 
const ServicosInc: React.FC<IServicosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const servicosService = new ServicosService(
    new ServicosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadServicos } = useServicosForm(
    ServicosEmpty(),
    servicosService
  );

  useEffect(() => {
    loadServicos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedServicos = await servicosService.saveServicos(data);

      if (savedServicos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/servicos');
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
      <ServicosForm
        servicosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ServicosInc;
