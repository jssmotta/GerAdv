"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoValorProcessoApi } from '../../Apis/ApiTipoValorProcesso';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoValorProcessoFormProps } from '../../Interfaces/interface.TipoValorProcesso';
import { TipoValorProcessoService } from '../../Services/TipoValorProcesso.service';
import { useTipoValorProcessoForm } from '../../Hooks/useTipoValorProcessoForm';
import { TipoValorProcessoEmpty } from '../../../Models/TipoValorProcesso'; 
import { TipoValorProcessoForm } from '../Forms/TipoValorProcesso';
 
const TipoValorProcessoInc: React.FC<ITipoValorProcessoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipovalorprocessoService = new TipoValorProcessoService(
    new TipoValorProcessoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoValorProcesso } = useTipoValorProcessoForm(
    TipoValorProcessoEmpty(),
    tipovalorprocessoService
  );

  useEffect(() => {
    loadTipoValorProcesso(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoValorProcesso = await tipovalorprocessoService.saveTipoValorProcesso(data);

      if (savedTipoValorProcesso.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipovalorprocesso');
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
      <TipoValorProcessoForm
        tipovalorprocessoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoValorProcessoInc;
