"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadorGrupoApi } from '../../Apis/ApiOperadorGrupo';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IOperadorGrupoFormProps } from '../../Interfaces/interface.OperadorGrupo';
import { OperadorGrupoService } from '../../Services/OperadorGrupo.service';
import { useOperadorGrupoForm } from '../../Hooks/useOperadorGrupoForm';
import { OperadorGrupoEmpty } from '../../../Models/OperadorGrupo'; 
import { OperadorGrupoForm } from '../Forms/OperadorGrupo';
 
const OperadorGrupoInc: React.FC<IOperadorGrupoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const operadorgrupoService = new OperadorGrupoService(
    new OperadorGrupoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOperadorGrupo } = useOperadorGrupoForm(
    OperadorGrupoEmpty(),
    operadorgrupoService
  );

  useEffect(() => {
    loadOperadorGrupo(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOperadorGrupo = await operadorgrupoService.saveOperadorGrupo(data);

      if (savedOperadorGrupo.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/operadorgrupo');
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
      <OperadorGrupoForm
        operadorgrupoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OperadorGrupoInc;
