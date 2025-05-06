"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ReuniaoPessoasApi } from '../../Apis/ApiReuniaoPessoas';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IReuniaoPessoasFormProps } from '../../Interfaces/interface.ReuniaoPessoas';
import { ReuniaoPessoasService } from '../../Services/ReuniaoPessoas.service';
import { useReuniaoPessoasForm } from '../../Hooks/useReuniaoPessoasForm';
import { ReuniaoPessoasEmpty } from '../../../Models/ReuniaoPessoas'; 
import { ReuniaoPessoasForm } from '../Forms/ReuniaoPessoas';
 
const ReuniaoPessoasInc: React.FC<IReuniaoPessoasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const reuniaopessoasService = new ReuniaoPessoasService(
    new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadReuniaoPessoas } = useReuniaoPessoasForm(
    ReuniaoPessoasEmpty(),
    reuniaopessoasService
  );

  useEffect(() => {
    loadReuniaoPessoas(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedReuniaoPessoas = await reuniaopessoasService.saveReuniaoPessoas(data);

      if (savedReuniaoPessoas.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/reuniaopessoas');
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
      <ReuniaoPessoasForm
        reuniaopessoasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ReuniaoPessoasInc;
