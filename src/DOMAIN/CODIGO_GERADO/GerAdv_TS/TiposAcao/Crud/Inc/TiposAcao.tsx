﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TiposAcaoApi } from '../../Apis/ApiTiposAcao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITiposAcaoFormProps } from '../../Interfaces/interface.TiposAcao';
import { TiposAcaoService } from '../../Services/TiposAcao.service';
import { useTiposAcaoForm } from '../../Hooks/useTiposAcaoForm';
import { TiposAcaoEmpty } from '../../../Models/TiposAcao'; 
import { TiposAcaoForm } from '../Forms/TiposAcao';
 
const TiposAcaoInc: React.FC<ITiposAcaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tiposacaoService = new TiposAcaoService(
    new TiposAcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTiposAcao } = useTiposAcaoForm(
    TiposAcaoEmpty(),
    tiposacaoService
  );

  useEffect(() => {
    loadTiposAcao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTiposAcao = await tiposacaoService.saveTiposAcao(data);

      if (savedTiposAcao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tiposacao');
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
      <TiposAcaoForm
        tiposacaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TiposAcaoInc;
