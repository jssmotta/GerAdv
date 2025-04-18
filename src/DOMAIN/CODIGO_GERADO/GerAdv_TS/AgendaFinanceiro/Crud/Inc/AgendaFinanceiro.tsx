﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaFinanceiroApi } from '../../Apis/ApiAgendaFinanceiro';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAgendaFinanceiroFormProps } from '../../Interfaces/interface.AgendaFinanceiro';
import { AgendaFinanceiroService } from '../../Services/AgendaFinanceiro.service';
import { useAgendaFinanceiroForm } from '../../Hooks/useAgendaFinanceiroForm';
import { AgendaFinanceiroEmpty } from '../../../Models/AgendaFinanceiro'; 
import { AgendaFinanceiroForm } from '../Forms/AgendaFinanceiro';
 
const AgendaFinanceiroInc: React.FC<IAgendaFinanceiroFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const agendafinanceiroService = new AgendaFinanceiroService(
    new AgendaFinanceiroApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAgendaFinanceiro } = useAgendaFinanceiroForm(
    AgendaFinanceiroEmpty(),
    agendafinanceiroService
  );

  useEffect(() => {
    loadAgendaFinanceiro(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAgendaFinanceiro = await agendafinanceiroService.saveAgendaFinanceiro(data);

      if (savedAgendaFinanceiro.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/agendafinanceiro');
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
      <AgendaFinanceiroForm
        agendafinanceiroData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AgendaFinanceiroInc;
