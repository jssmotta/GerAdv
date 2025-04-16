"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ContatoCRMOperadorApi } from '../../Apis/ApiContatoCRMOperador';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IContatoCRMOperadorFormProps } from '../../Interfaces/interface.ContatoCRMOperador';
import { ContatoCRMOperadorService } from '../../Services/ContatoCRMOperador.service';
import { useContatoCRMOperadorForm } from '../../Hooks/useContatoCRMOperadorForm';
import { ContatoCRMOperadorEmpty } from '../../../Models/ContatoCRMOperador'; 
import { ContatoCRMOperadorForm } from '../Forms/ContatoCRMOperador';
 
const ContatoCRMOperadorInc: React.FC<IContatoCRMOperadorFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const contatocrmoperadorService = new ContatoCRMOperadorService(
    new ContatoCRMOperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadContatoCRMOperador } = useContatoCRMOperadorForm(
    ContatoCRMOperadorEmpty(),
    contatocrmoperadorService
  );

  useEffect(() => {
    loadContatoCRMOperador(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedContatoCRMOperador = await contatocrmoperadorService.saveContatoCRMOperador(data);

      if (savedContatoCRMOperador.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/contatocrmoperador');
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
      <ContatoCRMOperadorForm
        contatocrmoperadorData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ContatoCRMOperadorInc;
