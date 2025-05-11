"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ColaboradoresApi } from '../../Apis/ApiColaboradores';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IColaboradoresFormProps } from '../../Interfaces/interface.Colaboradores';
import { ColaboradoresService } from '../../Services/Colaboradores.service';
import { useColaboradoresForm } from '../../Hooks/useColaboradoresForm';
import { ColaboradoresEmpty } from '../../../Models/Colaboradores'; 
import { ColaboradoresForm } from '../Forms/Colaboradores';
 
const ColaboradoresInc: React.FC<IColaboradoresFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const colaboradoresService = new ColaboradoresService(
    new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadColaboradores } = useColaboradoresForm(
    ColaboradoresEmpty(),
    colaboradoresService
  );

  useEffect(() => {
    loadColaboradores(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedColaboradores = await colaboradoresService.saveColaboradores(data);

      if (savedColaboradores.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/colaboradores');
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
      <ColaboradoresForm
        colaboradoresData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ColaboradoresInc;
