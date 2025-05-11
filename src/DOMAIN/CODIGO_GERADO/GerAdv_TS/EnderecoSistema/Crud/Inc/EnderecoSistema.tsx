"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EnderecoSistemaApi } from '../../Apis/ApiEnderecoSistema';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IEnderecoSistemaFormProps } from '../../Interfaces/interface.EnderecoSistema';
import { EnderecoSistemaService } from '../../Services/EnderecoSistema.service';
import { useEnderecoSistemaForm } from '../../Hooks/useEnderecoSistemaForm';
import { EnderecoSistemaEmpty } from '../../../Models/EnderecoSistema'; 
import { EnderecoSistemaForm } from '../Forms/EnderecoSistema';
 
const EnderecoSistemaInc: React.FC<IEnderecoSistemaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const enderecosistemaService = new EnderecoSistemaService(
    new EnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEnderecoSistema } = useEnderecoSistemaForm(
    EnderecoSistemaEmpty(),
    enderecosistemaService
  );

  useEffect(() => {
    loadEnderecoSistema(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEnderecoSistema = await enderecosistemaService.saveEnderecoSistema(data);

      if (savedEnderecoSistema.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/enderecosistema');
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
      <EnderecoSistemaForm
        enderecosistemaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EnderecoSistemaInc;
