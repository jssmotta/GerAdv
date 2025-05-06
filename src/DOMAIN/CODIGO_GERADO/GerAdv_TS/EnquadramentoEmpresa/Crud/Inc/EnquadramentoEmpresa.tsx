"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EnquadramentoEmpresaApi } from '../../Apis/ApiEnquadramentoEmpresa';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IEnquadramentoEmpresaFormProps } from '../../Interfaces/interface.EnquadramentoEmpresa';
import { EnquadramentoEmpresaService } from '../../Services/EnquadramentoEmpresa.service';
import { useEnquadramentoEmpresaForm } from '../../Hooks/useEnquadramentoEmpresaForm';
import { EnquadramentoEmpresaEmpty } from '../../../Models/EnquadramentoEmpresa'; 
import { EnquadramentoEmpresaForm } from '../Forms/EnquadramentoEmpresa';
 
const EnquadramentoEmpresaInc: React.FC<IEnquadramentoEmpresaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const enquadramentoempresaService = new EnquadramentoEmpresaService(
    new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEnquadramentoEmpresa } = useEnquadramentoEmpresaForm(
    EnquadramentoEmpresaEmpty(),
    enquadramentoempresaService
  );

  useEffect(() => {
    loadEnquadramentoEmpresa(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEnquadramentoEmpresa = await enquadramentoempresaService.saveEnquadramentoEmpresa(data);

      if (savedEnquadramentoEmpresa.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/enquadramentoempresa');
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
      <EnquadramentoEmpresaForm
        enquadramentoempresaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EnquadramentoEmpresaInc;
