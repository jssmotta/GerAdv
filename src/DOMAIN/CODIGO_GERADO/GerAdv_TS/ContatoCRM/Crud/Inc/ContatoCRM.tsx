"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ContatoCRMApi } from '../../Apis/ApiContatoCRM';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IContatoCRMFormProps } from '../../Interfaces/interface.ContatoCRM';
import { ContatoCRMService } from '../../Services/ContatoCRM.service';
import { useContatoCRMForm } from '../../Hooks/useContatoCRMForm';
import { ContatoCRMEmpty } from '../../../Models/ContatoCRM'; 
import { ContatoCRMForm } from '../Forms/ContatoCRM';
 
const ContatoCRMInc: React.FC<IContatoCRMFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const contatocrmService = new ContatoCRMService(
    new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadContatoCRM } = useContatoCRMForm(
    ContatoCRMEmpty(),
    contatocrmService
  );

  useEffect(() => {
    loadContatoCRM(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedContatoCRM = await contatocrmService.saveContatoCRM(data);

      if (savedContatoCRM.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/contatocrm');
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
      <ContatoCRMForm
        contatocrmData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ContatoCRMInc;
