"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProObservacoesApi } from '../../Apis/ApiProObservacoes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProObservacoesFormProps } from '../../Interfaces/interface.ProObservacoes';
import { ProObservacoesService } from '../../Services/ProObservacoes.service';
import { useProObservacoesForm } from '../../Hooks/useProObservacoesForm';
import { ProObservacoesEmpty } from '../../../Models/ProObservacoes'; 
import { ProObservacoesForm } from '../Forms/ProObservacoes';
 
const ProObservacoesInc: React.FC<IProObservacoesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const proobservacoesService = new ProObservacoesService(
    new ProObservacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProObservacoes } = useProObservacoesForm(
    ProObservacoesEmpty(),
    proobservacoesService
  );

  useEffect(() => {
    loadProObservacoes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProObservacoes = await proobservacoesService.saveProObservacoes(data);

      if (savedProObservacoes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/proobservacoes');
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
      <ProObservacoesForm
        proobservacoesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProObservacoesInc;
