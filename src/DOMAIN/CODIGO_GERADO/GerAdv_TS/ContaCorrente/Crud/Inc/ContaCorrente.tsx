"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ContaCorrenteApi } from '../../Apis/ApiContaCorrente';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IContaCorrenteFormProps } from '../../Interfaces/interface.ContaCorrente';
import { ContaCorrenteService } from '../../Services/ContaCorrente.service';
import { useContaCorrenteForm } from '../../Hooks/useContaCorrenteForm';
import { ContaCorrenteEmpty } from '../../../Models/ContaCorrente'; 
import { ContaCorrenteForm } from '../Forms/ContaCorrente';
 
const ContaCorrenteInc: React.FC<IContaCorrenteFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const contacorrenteService = new ContaCorrenteService(
    new ContaCorrenteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadContaCorrente } = useContaCorrenteForm(
    ContaCorrenteEmpty(),
    contacorrenteService
  );

  useEffect(() => {
    loadContaCorrente(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedContaCorrente = await contacorrenteService.saveContaCorrente(data);

      if (savedContaCorrente.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/contacorrente');
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
      <ContaCorrenteForm
        contacorrenteData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ContaCorrenteInc;
