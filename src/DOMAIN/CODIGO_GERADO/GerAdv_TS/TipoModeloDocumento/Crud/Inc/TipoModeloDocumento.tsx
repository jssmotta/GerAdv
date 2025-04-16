"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoModeloDocumentoApi } from '../../Apis/ApiTipoModeloDocumento';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoModeloDocumentoFormProps } from '../../Interfaces/interface.TipoModeloDocumento';
import { TipoModeloDocumentoService } from '../../Services/TipoModeloDocumento.service';
import { useTipoModeloDocumentoForm } from '../../Hooks/useTipoModeloDocumentoForm';
import { TipoModeloDocumentoEmpty } from '../../../Models/TipoModeloDocumento'; 
import { TipoModeloDocumentoForm } from '../Forms/TipoModeloDocumento';
 
const TipoModeloDocumentoInc: React.FC<ITipoModeloDocumentoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipomodelodocumentoService = new TipoModeloDocumentoService(
    new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoModeloDocumento } = useTipoModeloDocumentoForm(
    TipoModeloDocumentoEmpty(),
    tipomodelodocumentoService
  );

  useEffect(() => {
    loadTipoModeloDocumento(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoModeloDocumento = await tipomodelodocumentoService.saveTipoModeloDocumento(data);

      if (savedTipoModeloDocumento.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipomodelodocumento');
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
      <TipoModeloDocumentoForm
        tipomodelodocumentoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoModeloDocumentoInc;
