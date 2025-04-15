"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoCompromissoApi } from '../../Apis/ApiTipoCompromisso';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoCompromissoFormProps } from '../../Interfaces/interface.TipoCompromisso';
import { TipoCompromissoService } from '../../Services/TipoCompromisso.service';
import { useTipoCompromissoForm } from '../../Hooks/useTipoCompromissoForm';
import { TipoCompromissoEmpty } from '../../../Models/TipoCompromisso'; 
import { TipoCompromissoForm } from '../Forms/TipoCompromisso';
 
const TipoCompromissoInc: React.FC<ITipoCompromissoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipocompromissoService = new TipoCompromissoService(
    new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoCompromisso } = useTipoCompromissoForm(
    TipoCompromissoEmpty(),
    tipocompromissoService
  );

  useEffect(() => {
    loadTipoCompromisso(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoCompromisso = await tipocompromissoService.saveTipoCompromisso(data);

      if (savedTipoCompromisso.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipocompromisso');
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
      <TipoCompromissoForm
        tipocompromissoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoCompromissoInc;
