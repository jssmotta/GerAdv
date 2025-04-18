﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoProDespositoApi } from '../../Apis/ApiTipoProDesposito';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoProDespositoFormProps } from '../../Interfaces/interface.TipoProDesposito';
import { TipoProDespositoService } from '../../Services/TipoProDesposito.service';
import { useTipoProDespositoForm } from '../../Hooks/useTipoProDespositoForm';
import { TipoProDespositoEmpty } from '../../../Models/TipoProDesposito'; 
import { TipoProDespositoForm } from '../Forms/TipoProDesposito';
 
const TipoProDespositoInc: React.FC<ITipoProDespositoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipoprodespositoService = new TipoProDespositoService(
    new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoProDesposito } = useTipoProDespositoForm(
    TipoProDespositoEmpty(),
    tipoprodespositoService
  );

  useEffect(() => {
    loadTipoProDesposito(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoProDesposito = await tipoprodespositoService.saveTipoProDesposito(data);

      if (savedTipoProDesposito.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipoprodesposito');
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
      <TipoProDespositoForm
        tipoprodespositoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoProDespositoInc;
