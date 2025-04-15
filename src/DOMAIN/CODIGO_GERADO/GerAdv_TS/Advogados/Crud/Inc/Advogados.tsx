"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AdvogadosApi } from '../../Apis/ApiAdvogados';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAdvogadosFormProps } from '../../Interfaces/interface.Advogados';
import { AdvogadosService } from '../../Services/Advogados.service';
import { useAdvogadosForm } from '../../Hooks/useAdvogadosForm';
import { AdvogadosEmpty } from '../../../Models/Advogados'; 
import { AdvogadosForm } from '../Forms/Advogados';
 
const AdvogadosInc: React.FC<IAdvogadosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const advogadosService = new AdvogadosService(
    new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAdvogados } = useAdvogadosForm(
    AdvogadosEmpty(),
    advogadosService
  );

  useEffect(() => {
    loadAdvogados(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAdvogados = await advogadosService.saveAdvogados(data);

      if (savedAdvogados.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/advogados');
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
      <AdvogadosForm
        advogadosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AdvogadosInc;
