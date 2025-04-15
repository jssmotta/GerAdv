"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadorGruposApi } from '../../Apis/ApiOperadorGrupos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IOperadorGruposFormProps } from '../../Interfaces/interface.OperadorGrupos';
import { OperadorGruposService } from '../../Services/OperadorGrupos.service';
import { useOperadorGruposForm } from '../../Hooks/useOperadorGruposForm';
import { OperadorGruposEmpty } from '../../../Models/OperadorGrupos'; 
import { OperadorGruposForm } from '../Forms/OperadorGrupos';
 
const OperadorGruposInc: React.FC<IOperadorGruposFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const operadorgruposService = new OperadorGruposService(
    new OperadorGruposApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOperadorGrupos } = useOperadorGruposForm(
    OperadorGruposEmpty(),
    operadorgruposService
  );

  useEffect(() => {
    loadOperadorGrupos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOperadorGrupos = await operadorgruposService.saveOperadorGrupos(data);

      if (savedOperadorGrupos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/operadorgrupos');
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
      <OperadorGruposForm
        operadorgruposData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OperadorGruposInc;
