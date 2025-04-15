"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { HistoricoApi } from '../../Apis/ApiHistorico';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IHistoricoFormProps } from '../../Interfaces/interface.Historico';
import { HistoricoService } from '../../Services/Historico.service';
import { useHistoricoForm } from '../../Hooks/useHistoricoForm';
import { HistoricoEmpty } from '../../../Models/Historico'; 
import { HistoricoForm } from '../Forms/Historico';
 
const HistoricoInc: React.FC<IHistoricoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const historicoService = new HistoricoService(
    new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadHistorico } = useHistoricoForm(
    HistoricoEmpty(),
    historicoService
  );

  useEffect(() => {
    loadHistorico(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedHistorico = await historicoService.saveHistorico(data);

      if (savedHistorico.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/historico');
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
      <HistoricoForm
        historicoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default HistoricoInc;
