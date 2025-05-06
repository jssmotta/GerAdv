"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoContatoCRMApi } from '../../Apis/ApiTipoContatoCRM';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ITipoContatoCRMFormProps } from '../../Interfaces/interface.TipoContatoCRM';
import { TipoContatoCRMService } from '../../Services/TipoContatoCRM.service';
import { useTipoContatoCRMForm } from '../../Hooks/useTipoContatoCRMForm';
import { TipoContatoCRMEmpty } from '../../../Models/TipoContatoCRM'; 
import { TipoContatoCRMForm } from '../Forms/TipoContatoCRM';
 
const TipoContatoCRMInc: React.FC<ITipoContatoCRMFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipocontatocrmService = new TipoContatoCRMService(
    new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoContatoCRM } = useTipoContatoCRMForm(
    TipoContatoCRMEmpty(),
    tipocontatocrmService
  );

  useEffect(() => {
    loadTipoContatoCRM(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoContatoCRM = await tipocontatocrmService.saveTipoContatoCRM(data);

      if (savedTipoContatoCRM.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipocontatocrm');
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
      <TipoContatoCRMForm
        tipocontatocrmData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoContatoCRMInc;
