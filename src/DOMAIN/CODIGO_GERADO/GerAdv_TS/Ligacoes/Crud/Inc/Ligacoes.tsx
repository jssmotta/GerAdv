"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { LigacoesApi } from '../../Apis/ApiLigacoes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ILigacoesFormProps } from '../../Interfaces/interface.Ligacoes';
import { LigacoesService } from '../../Services/Ligacoes.service';
import { useLigacoesForm } from '../../Hooks/useLigacoesForm';
import { LigacoesEmpty } from '../../../Models/Ligacoes'; 
import { LigacoesForm } from '../Forms/Ligacoes';
 
const LigacoesInc: React.FC<ILigacoesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const ligacoesService = new LigacoesService(
    new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadLigacoes } = useLigacoesForm(
    LigacoesEmpty(),
    ligacoesService
  );

  useEffect(() => {
    loadLigacoes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedLigacoes = await ligacoesService.saveLigacoes(data);

      if (savedLigacoes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/ligacoes');
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
      <LigacoesForm
        ligacoesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default LigacoesInc;
