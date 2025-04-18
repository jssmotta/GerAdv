﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { SituacaoApi } from '../../Apis/ApiSituacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ISituacaoFormProps } from '../../Interfaces/interface.Situacao';
import { SituacaoService } from '../../Services/Situacao.service';
import { useSituacaoForm } from '../../Hooks/useSituacaoForm';
import { SituacaoEmpty } from '../../../Models/Situacao'; 
import { SituacaoForm } from '../Forms/Situacao';
 
const SituacaoInc: React.FC<ISituacaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const situacaoService = new SituacaoService(
    new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadSituacao } = useSituacaoForm(
    SituacaoEmpty(),
    situacaoService
  );

  useEffect(() => {
    loadSituacao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedSituacao = await situacaoService.saveSituacao(data);

      if (savedSituacao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/situacao');
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
      <SituacaoForm
        situacaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default SituacaoInc;
