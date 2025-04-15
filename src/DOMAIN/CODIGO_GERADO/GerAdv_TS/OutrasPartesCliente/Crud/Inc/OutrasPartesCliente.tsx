"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OutrasPartesClienteApi } from '../../Apis/ApiOutrasPartesCliente';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IOutrasPartesClienteFormProps } from '../../Interfaces/interface.OutrasPartesCliente';
import { OutrasPartesClienteService } from '../../Services/OutrasPartesCliente.service';
import { useOutrasPartesClienteForm } from '../../Hooks/useOutrasPartesClienteForm';
import { OutrasPartesClienteEmpty } from '../../../Models/OutrasPartesCliente'; 
import { OutrasPartesClienteForm } from '../Forms/OutrasPartesCliente';
 
const OutrasPartesClienteInc: React.FC<IOutrasPartesClienteFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const outraspartesclienteService = new OutrasPartesClienteService(
    new OutrasPartesClienteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOutrasPartesCliente } = useOutrasPartesClienteForm(
    OutrasPartesClienteEmpty(),
    outraspartesclienteService
  );

  useEffect(() => {
    loadOutrasPartesCliente(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOutrasPartesCliente = await outraspartesclienteService.saveOutrasPartesCliente(data);

      if (savedOutrasPartesCliente.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/outraspartescliente');
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
      <OutrasPartesClienteForm
        outraspartesclienteData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OutrasPartesClienteInc;
