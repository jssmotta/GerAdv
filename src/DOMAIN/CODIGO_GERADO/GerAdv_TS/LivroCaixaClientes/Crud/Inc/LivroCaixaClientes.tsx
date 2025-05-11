"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { LivroCaixaClientesApi } from '../../Apis/ApiLivroCaixaClientes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ILivroCaixaClientesFormProps } from '../../Interfaces/interface.LivroCaixaClientes';
import { LivroCaixaClientesService } from '../../Services/LivroCaixaClientes.service';
import { useLivroCaixaClientesForm } from '../../Hooks/useLivroCaixaClientesForm';
import { LivroCaixaClientesEmpty } from '../../../Models/LivroCaixaClientes'; 
import { LivroCaixaClientesForm } from '../Forms/LivroCaixaClientes';
 
const LivroCaixaClientesInc: React.FC<ILivroCaixaClientesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const livrocaixaclientesService = new LivroCaixaClientesService(
    new LivroCaixaClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadLivroCaixaClientes } = useLivroCaixaClientesForm(
    LivroCaixaClientesEmpty(),
    livrocaixaclientesService
  );

  useEffect(() => {
    loadLivroCaixaClientes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedLivroCaixaClientes = await livrocaixaclientesService.saveLivroCaixaClientes(data);

      if (savedLivroCaixaClientes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/livrocaixaclientes');
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
      <LivroCaixaClientesForm
        livrocaixaclientesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default LivroCaixaClientesInc;
