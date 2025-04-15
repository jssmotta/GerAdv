"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoRecursoApi } from '../../Apis/ApiTipoRecurso';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoRecursoFormProps } from '../../Interfaces/interface.TipoRecurso';
import { TipoRecursoService } from '../../Services/TipoRecurso.service';
import { useTipoRecursoForm } from '../../Hooks/useTipoRecursoForm';
import { TipoRecursoEmpty } from '../../../Models/TipoRecurso'; 
import { TipoRecursoForm } from '../Forms/TipoRecurso';
 
const TipoRecursoInc: React.FC<ITipoRecursoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tiporecursoService = new TipoRecursoService(
    new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoRecurso } = useTipoRecursoForm(
    TipoRecursoEmpty(),
    tiporecursoService
  );

  useEffect(() => {
    loadTipoRecurso(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoRecurso = await tiporecursoService.saveTipoRecurso(data);

      if (savedTipoRecurso.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tiporecurso');
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
      <TipoRecursoForm
        tiporecursoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoRecursoInc;
