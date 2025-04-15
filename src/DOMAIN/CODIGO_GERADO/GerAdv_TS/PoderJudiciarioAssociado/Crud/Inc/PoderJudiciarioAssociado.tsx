"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PoderJudiciarioAssociadoApi } from '../../Apis/ApiPoderJudiciarioAssociado';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IPoderJudiciarioAssociadoFormProps } from '../../Interfaces/interface.PoderJudiciarioAssociado';
import { PoderJudiciarioAssociadoService } from '../../Services/PoderJudiciarioAssociado.service';
import { usePoderJudiciarioAssociadoForm } from '../../Hooks/usePoderJudiciarioAssociadoForm';
import { PoderJudiciarioAssociadoEmpty } from '../../../Models/PoderJudiciarioAssociado'; 
import { PoderJudiciarioAssociadoForm } from '../Forms/PoderJudiciarioAssociado';
 
const PoderJudiciarioAssociadoInc: React.FC<IPoderJudiciarioAssociadoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const poderjudiciarioassociadoService = new PoderJudiciarioAssociadoService(
    new PoderJudiciarioAssociadoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPoderJudiciarioAssociado } = usePoderJudiciarioAssociadoForm(
    PoderJudiciarioAssociadoEmpty(),
    poderjudiciarioassociadoService
  );

  useEffect(() => {
    loadPoderJudiciarioAssociado(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPoderJudiciarioAssociado = await poderjudiciarioassociadoService.savePoderJudiciarioAssociado(data);

      if (savedPoderJudiciarioAssociado.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/poderjudiciarioassociado');
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
      <PoderJudiciarioAssociadoForm
        poderjudiciarioassociadoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PoderJudiciarioAssociadoInc;
