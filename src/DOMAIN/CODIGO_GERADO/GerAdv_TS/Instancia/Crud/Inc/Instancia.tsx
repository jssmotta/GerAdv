"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { InstanciaApi } from '../../Apis/ApiInstancia';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IInstanciaFormProps } from '../../Interfaces/interface.Instancia';
import { InstanciaService } from '../../Services/Instancia.service';
import { useInstanciaForm } from '../../Hooks/useInstanciaForm';
import { InstanciaEmpty } from '../../../Models/Instancia'; 
import { InstanciaForm } from '../Forms/Instancia';
 
const InstanciaInc: React.FC<IInstanciaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const instanciaService = new InstanciaService(
    new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadInstancia } = useInstanciaForm(
    InstanciaEmpty(),
    instanciaService
  );

  useEffect(() => {
    loadInstancia(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedInstancia = await instanciaService.saveInstancia(data);

      if (savedInstancia.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/instancia');
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
      <InstanciaForm
        instanciaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default InstanciaInc;
