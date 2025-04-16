"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProDespesasApi } from '../../Apis/ApiProDespesas';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProDespesasFormProps } from '../../Interfaces/interface.ProDespesas';
import { ProDespesasService } from '../../Services/ProDespesas.service';
import { useProDespesasForm } from '../../Hooks/useProDespesasForm';
import { ProDespesasEmpty } from '../../../Models/ProDespesas'; 
import { ProDespesasForm } from '../Forms/ProDespesas';
 
const ProDespesasInc: React.FC<IProDespesasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const prodespesasService = new ProDespesasService(
    new ProDespesasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProDespesas } = useProDespesasForm(
    ProDespesasEmpty(),
    prodespesasService
  );

  useEffect(() => {
    loadProDespesas(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProDespesas = await prodespesasService.saveProDespesas(data);

      if (savedProDespesas.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/prodespesas');
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
      <ProDespesasForm
        prodespesasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProDespesasInc;
