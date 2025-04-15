"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ContratosApi } from '../../Apis/ApiContratos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IContratosFormProps } from '../../Interfaces/interface.Contratos';
import { ContratosService } from '../../Services/Contratos.service';
import { useContratosForm } from '../../Hooks/useContratosForm';
import { ContratosEmpty } from '../../../Models/Contratos'; 
import { ContratosForm } from '../Forms/Contratos';
 
const ContratosInc: React.FC<IContratosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const contratosService = new ContratosService(
    new ContratosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadContratos } = useContratosForm(
    ContratosEmpty(),
    contratosService
  );

  useEffect(() => {
    loadContratos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedContratos = await contratosService.saveContratos(data);

      if (savedContratos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/contratos');
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
      <ContratosForm
        contratosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ContratosInc;
