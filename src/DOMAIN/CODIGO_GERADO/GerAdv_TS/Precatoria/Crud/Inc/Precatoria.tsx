﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PrecatoriaApi } from '../../Apis/ApiPrecatoria';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IPrecatoriaFormProps } from '../../Interfaces/interface.Precatoria';
import { PrecatoriaService } from '../../Services/Precatoria.service';
import { usePrecatoriaForm } from '../../Hooks/usePrecatoriaForm';
import { PrecatoriaEmpty } from '../../../Models/Precatoria'; 
import { PrecatoriaForm } from '../Forms/Precatoria';
 
const PrecatoriaInc: React.FC<IPrecatoriaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const precatoriaService = new PrecatoriaService(
    new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPrecatoria } = usePrecatoriaForm(
    PrecatoriaEmpty(),
    precatoriaService
  );

  useEffect(() => {
    loadPrecatoria(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPrecatoria = await precatoriaService.savePrecatoria(data);

      if (savedPrecatoria.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/precatoria');
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
      <PrecatoriaForm
        precatoriaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PrecatoriaInc;
