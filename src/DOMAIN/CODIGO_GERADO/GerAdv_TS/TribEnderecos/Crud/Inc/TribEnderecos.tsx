"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TribEnderecosApi } from '../../Apis/ApiTribEnderecos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITribEnderecosFormProps } from '../../Interfaces/interface.TribEnderecos';
import { TribEnderecosService } from '../../Services/TribEnderecos.service';
import { useTribEnderecosForm } from '../../Hooks/useTribEnderecosForm';
import { TribEnderecosEmpty } from '../../../Models/TribEnderecos'; 
import { TribEnderecosForm } from '../Forms/TribEnderecos';
 
const TribEnderecosInc: React.FC<ITribEnderecosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tribenderecosService = new TribEnderecosService(
    new TribEnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTribEnderecos } = useTribEnderecosForm(
    TribEnderecosEmpty(),
    tribenderecosService
  );

  useEffect(() => {
    loadTribEnderecos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTribEnderecos = await tribenderecosService.saveTribEnderecos(data);

      if (savedTribEnderecos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tribenderecos');
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
      <TribEnderecosForm
        tribenderecosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TribEnderecosInc;
