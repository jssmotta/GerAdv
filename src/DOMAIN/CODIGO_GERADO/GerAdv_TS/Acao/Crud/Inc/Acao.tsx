"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AcaoApi } from '../../Apis/ApiAcao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAcaoFormProps } from '../../Interfaces/interface.Acao';
import { AcaoService } from '../../Services/Acao.service';
import { useAcaoForm } from '../../Hooks/useAcaoForm';
import { AcaoEmpty } from '../../../Models/Acao'; 
import { AcaoForm } from '../Forms/Acao';
 
const AcaoInc: React.FC<IAcaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const acaoService = new AcaoService(
    new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAcao } = useAcaoForm(
    AcaoEmpty(),
    acaoService
  );

  useEffect(() => {
    loadAcao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAcao = await acaoService.saveAcao(data);

      if (savedAcao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/acao');
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
      <AcaoForm
        acaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AcaoInc;
