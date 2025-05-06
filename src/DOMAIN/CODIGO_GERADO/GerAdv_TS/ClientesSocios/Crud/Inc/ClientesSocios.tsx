"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ClientesSociosApi } from '../../Apis/ApiClientesSocios';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IClientesSociosFormProps } from '../../Interfaces/interface.ClientesSocios';
import { ClientesSociosService } from '../../Services/ClientesSocios.service';
import { useClientesSociosForm } from '../../Hooks/useClientesSociosForm';
import { ClientesSociosEmpty } from '../../../Models/ClientesSocios'; 
import { ClientesSociosForm } from '../Forms/ClientesSocios';
 
const ClientesSociosInc: React.FC<IClientesSociosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const clientessociosService = new ClientesSociosService(
    new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadClientesSocios } = useClientesSociosForm(
    ClientesSociosEmpty(),
    clientessociosService
  );

  useEffect(() => {
    loadClientesSocios(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedClientesSocios = await clientessociosService.saveClientesSocios(data);

      if (savedClientesSocios.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/clientessocios');
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
      <ClientesSociosForm
        clientessociosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ClientesSociosInc;
