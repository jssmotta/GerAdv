"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ClientesApi } from '../../Apis/ApiClientes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IClientesFormProps } from '../../Interfaces/interface.Clientes';
import { ClientesService } from '../../Services/Clientes.service';
import { useClientesForm } from '../../Hooks/useClientesForm';
import { ClientesEmpty } from '../../../Models/Clientes'; 
import { ClientesForm } from '../Forms/Clientes';
 
const ClientesInc: React.FC<IClientesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const clientesService = new ClientesService(
    new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadClientes } = useClientesForm(
    ClientesEmpty(),
    clientesService
  );

  useEffect(() => {
    loadClientes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedClientes = await clientesService.saveClientes(data);

      if (savedClientes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/clientes');
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
      <ClientesForm
        clientesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ClientesInc;
