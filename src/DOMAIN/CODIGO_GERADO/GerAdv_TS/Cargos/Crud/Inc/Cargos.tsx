﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { CargosApi } from '../../Apis/ApiCargos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ICargosFormProps } from '../../Interfaces/interface.Cargos';
import { CargosService } from '../../Services/Cargos.service';
import { useCargosForm } from '../../Hooks/useCargosForm';
import { CargosEmpty } from '../../../Models/Cargos'; 
import { CargosForm } from '../Forms/Cargos';
 
const CargosInc: React.FC<ICargosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const cargosService = new CargosService(
    new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadCargos } = useCargosForm(
    CargosEmpty(),
    cargosService
  );

  useEffect(() => {
    loadCargos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedCargos = await cargosService.saveCargos(data);

      if (savedCargos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/cargos');
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
      <CargosForm
        cargosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default CargosInc;
