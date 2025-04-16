"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { DadosProcuracaoApi } from '../../Apis/ApiDadosProcuracao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IDadosProcuracaoFormProps } from '../../Interfaces/interface.DadosProcuracao';
import { DadosProcuracaoService } from '../../Services/DadosProcuracao.service';
import { useDadosProcuracaoForm } from '../../Hooks/useDadosProcuracaoForm';
import { DadosProcuracaoEmpty } from '../../../Models/DadosProcuracao'; 
import { DadosProcuracaoForm } from '../Forms/DadosProcuracao';
 
const DadosProcuracaoInc: React.FC<IDadosProcuracaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const dadosprocuracaoService = new DadosProcuracaoService(
    new DadosProcuracaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadDadosProcuracao } = useDadosProcuracaoForm(
    DadosProcuracaoEmpty(),
    dadosprocuracaoService
  );

  useEffect(() => {
    loadDadosProcuracao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedDadosProcuracao = await dadosprocuracaoService.saveDadosProcuracao(data);

      if (savedDadosProcuracao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/dadosprocuracao');
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
      <DadosProcuracaoForm
        dadosprocuracaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default DadosProcuracaoInc;
