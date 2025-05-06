"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { SetorApi } from '../../Apis/ApiSetor';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ISetorFormProps } from '../../Interfaces/interface.Setor';
import { SetorService } from '../../Services/Setor.service';
import { useSetorForm } from '../../Hooks/useSetorForm';
import { SetorEmpty } from '../../../Models/Setor'; 
import { SetorForm } from '../Forms/Setor';
 
const SetorInc: React.FC<ISetorFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const setorService = new SetorService(
    new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadSetor } = useSetorForm(
    SetorEmpty(),
    setorService
  );

  useEffect(() => {
    loadSetor(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedSetor = await setorService.saveSetor(data);

      if (savedSetor.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/setor');
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
      <SetorForm
        setorData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default SetorInc;
