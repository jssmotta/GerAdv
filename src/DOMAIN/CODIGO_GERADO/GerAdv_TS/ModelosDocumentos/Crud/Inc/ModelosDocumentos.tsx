"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ModelosDocumentosApi } from '../../Apis/ApiModelosDocumentos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IModelosDocumentosFormProps } from '../../Interfaces/interface.ModelosDocumentos';
import { ModelosDocumentosService } from '../../Services/ModelosDocumentos.service';
import { useModelosDocumentosForm } from '../../Hooks/useModelosDocumentosForm';
import { ModelosDocumentosEmpty } from '../../../Models/ModelosDocumentos'; 
import { ModelosDocumentosForm } from '../Forms/ModelosDocumentos';
 
const ModelosDocumentosInc: React.FC<IModelosDocumentosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const modelosdocumentosService = new ModelosDocumentosService(
    new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadModelosDocumentos } = useModelosDocumentosForm(
    ModelosDocumentosEmpty(),
    modelosdocumentosService
  );

  useEffect(() => {
    loadModelosDocumentos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedModelosDocumentos = await modelosdocumentosService.saveModelosDocumentos(data);

      if (savedModelosDocumentos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/modelosdocumentos');
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
      <ModelosDocumentosForm
        modelosdocumentosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ModelosDocumentosInc;
