"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProProcuradoresApi } from '../../Apis/ApiProProcuradores';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IProProcuradoresFormProps } from '../../Interfaces/interface.ProProcuradores';
import { ProProcuradoresService } from '../../Services/ProProcuradores.service';
import { useProProcuradoresForm } from '../../Hooks/useProProcuradoresForm';
import { ProProcuradoresEmpty } from '../../../Models/ProProcuradores'; 
import { ProProcuradoresForm } from '../Forms/ProProcuradores';
 
const ProProcuradoresInc: React.FC<IProProcuradoresFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const proprocuradoresService = new ProProcuradoresService(
    new ProProcuradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProProcuradores } = useProProcuradoresForm(
    ProProcuradoresEmpty(),
    proprocuradoresService
  );

  useEffect(() => {
    loadProProcuradores(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProProcuradores = await proprocuradoresService.saveProProcuradores(data);

      if (savedProProcuradores.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/proprocuradores');
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
      <ProProcuradoresForm
        proprocuradoresData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProProcuradoresInc;
