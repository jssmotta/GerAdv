﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { RegimeTributacaoApi } from '../../Apis/ApiRegimeTributacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IRegimeTributacaoFormProps } from '../../Interfaces/interface.RegimeTributacao';
import { RegimeTributacaoService } from '../../Services/RegimeTributacao.service';
import { useRegimeTributacaoForm } from '../../Hooks/useRegimeTributacaoForm';
import { RegimeTributacaoEmpty } from '../../../Models/RegimeTributacao'; 
import { RegimeTributacaoForm } from '../Forms/RegimeTributacao';
 
const RegimeTributacaoInc: React.FC<IRegimeTributacaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const regimetributacaoService = new RegimeTributacaoService(
    new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadRegimeTributacao } = useRegimeTributacaoForm(
    RegimeTributacaoEmpty(),
    regimetributacaoService
  );

  useEffect(() => {
    loadRegimeTributacao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedRegimeTributacao = await regimetributacaoService.saveRegimeTributacao(data);

      if (savedRegimeTributacao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/regimetributacao');
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
      <RegimeTributacaoForm
        regimetributacaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default RegimeTributacaoInc;
