"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProTipoBaixaApi } from '../../Apis/ApiProTipoBaixa';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProTipoBaixaFormProps } from '../../Interfaces/interface.ProTipoBaixa';
import { ProTipoBaixaService } from '../../Services/ProTipoBaixa.service';
import { useProTipoBaixaForm } from '../../Hooks/useProTipoBaixaForm';
import { ProTipoBaixaEmpty } from '../../../Models/ProTipoBaixa'; 
import { ProTipoBaixaForm } from '../Forms/ProTipoBaixa';
 
const ProTipoBaixaInc: React.FC<IProTipoBaixaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const protipobaixaService = new ProTipoBaixaService(
    new ProTipoBaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProTipoBaixa } = useProTipoBaixaForm(
    ProTipoBaixaEmpty(),
    protipobaixaService
  );

  useEffect(() => {
    loadProTipoBaixa(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProTipoBaixa = await protipobaixaService.saveProTipoBaixa(data);

      if (savedProTipoBaixa.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/protipobaixa');
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
      <ProTipoBaixaForm
        protipobaixaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProTipoBaixaInc;
