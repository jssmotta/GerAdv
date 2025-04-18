﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoOrigemSucumbenciaApi } from '../../Apis/ApiTipoOrigemSucumbencia';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoOrigemSucumbenciaFormProps } from '../../Interfaces/interface.TipoOrigemSucumbencia';
import { TipoOrigemSucumbenciaService } from '../../Services/TipoOrigemSucumbencia.service';
import { useTipoOrigemSucumbenciaForm } from '../../Hooks/useTipoOrigemSucumbenciaForm';
import { TipoOrigemSucumbenciaEmpty } from '../../../Models/TipoOrigemSucumbencia'; 
import { TipoOrigemSucumbenciaForm } from '../Forms/TipoOrigemSucumbencia';
 
const TipoOrigemSucumbenciaInc: React.FC<ITipoOrigemSucumbenciaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipoorigemsucumbenciaService = new TipoOrigemSucumbenciaService(
    new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoOrigemSucumbencia } = useTipoOrigemSucumbenciaForm(
    TipoOrigemSucumbenciaEmpty(),
    tipoorigemsucumbenciaService
  );

  useEffect(() => {
    loadTipoOrigemSucumbencia(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoOrigemSucumbencia = await tipoorigemsucumbenciaService.saveTipoOrigemSucumbencia(data);

      if (savedTipoOrigemSucumbencia.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipoorigemsucumbencia');
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
      <TipoOrigemSucumbenciaForm
        tipoorigemsucumbenciaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoOrigemSucumbenciaInc;
