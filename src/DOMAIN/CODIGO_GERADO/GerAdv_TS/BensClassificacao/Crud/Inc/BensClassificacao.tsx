"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { BensClassificacaoApi } from '../../Apis/ApiBensClassificacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IBensClassificacaoFormProps } from '../../Interfaces/interface.BensClassificacao';
import { BensClassificacaoService } from '../../Services/BensClassificacao.service';
import { useBensClassificacaoForm } from '../../Hooks/useBensClassificacaoForm';
import { BensClassificacaoEmpty } from '../../../Models/BensClassificacao'; 
import { BensClassificacaoForm } from '../Forms/BensClassificacao';
 
const BensClassificacaoInc: React.FC<IBensClassificacaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const bensclassificacaoService = new BensClassificacaoService(
    new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadBensClassificacao } = useBensClassificacaoForm(
    BensClassificacaoEmpty(),
    bensclassificacaoService
  );

  useEffect(() => {
    loadBensClassificacao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedBensClassificacao = await bensclassificacaoService.saveBensClassificacao(data);

      if (savedBensClassificacao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/bensclassificacao');
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
      <BensClassificacaoForm
        bensclassificacaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default BensClassificacaoInc;
