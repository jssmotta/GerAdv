"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { LivroCaixaApi } from '../../Apis/ApiLivroCaixa';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ILivroCaixaFormProps } from '../../Interfaces/interface.LivroCaixa';
import { LivroCaixaService } from '../../Services/LivroCaixa.service';
import { useLivroCaixaForm } from '../../Hooks/useLivroCaixaForm';
import { LivroCaixaEmpty } from '../../../Models/LivroCaixa'; 
import { LivroCaixaForm } from '../Forms/LivroCaixa';
 
const LivroCaixaInc: React.FC<ILivroCaixaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const livrocaixaService = new LivroCaixaService(
    new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadLivroCaixa } = useLivroCaixaForm(
    LivroCaixaEmpty(),
    livrocaixaService
  );

  useEffect(() => {
    loadLivroCaixa(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedLivroCaixa = await livrocaixaService.saveLivroCaixa(data);

      if (savedLivroCaixa.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/livrocaixa');
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
      <LivroCaixaForm
        livrocaixaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default LivroCaixaInc;
