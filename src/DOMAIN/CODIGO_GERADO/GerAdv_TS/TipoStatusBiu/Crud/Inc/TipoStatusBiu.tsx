"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoStatusBiuApi } from '../../Apis/ApiTipoStatusBiu';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoStatusBiuFormProps } from '../../Interfaces/interface.TipoStatusBiu';
import { TipoStatusBiuService } from '../../Services/TipoStatusBiu.service';
import { useTipoStatusBiuForm } from '../../Hooks/useTipoStatusBiuForm';
import { TipoStatusBiuEmpty } from '../../../Models/TipoStatusBiu'; 
import { TipoStatusBiuForm } from '../Forms/TipoStatusBiu';
 
const TipoStatusBiuInc: React.FC<ITipoStatusBiuFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipostatusbiuService = new TipoStatusBiuService(
    new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoStatusBiu } = useTipoStatusBiuForm(
    TipoStatusBiuEmpty(),
    tipostatusbiuService
  );

  useEffect(() => {
    loadTipoStatusBiu(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoStatusBiu = await tipostatusbiuService.saveTipoStatusBiu(data);

      if (savedTipoStatusBiu.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipostatusbiu');
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
      <TipoStatusBiuForm
        tipostatusbiuData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoStatusBiuInc;
