"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EnderecosApi } from '../../Apis/ApiEnderecos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IEnderecosFormProps } from '../../Interfaces/interface.Enderecos';
import { EnderecosService } from '../../Services/Enderecos.service';
import { useEnderecosForm } from '../../Hooks/useEnderecosForm';
import { EnderecosEmpty } from '../../../Models/Enderecos'; 
import { EnderecosForm } from '../Forms/Enderecos';
 
const EnderecosInc: React.FC<IEnderecosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const enderecosService = new EnderecosService(
    new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEnderecos } = useEnderecosForm(
    EnderecosEmpty(),
    enderecosService
  );

  useEffect(() => {
    loadEnderecos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEnderecos = await enderecosService.saveEnderecos(data);

      if (savedEnderecos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/enderecos');
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
      <EnderecosForm
        enderecosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EnderecosInc;
