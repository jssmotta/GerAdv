"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ObjetosApi } from '../../Apis/ApiObjetos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IObjetosFormProps } from '../../Interfaces/interface.Objetos';
import { ObjetosService } from '../../Services/Objetos.service';
import { useObjetosForm } from '../../Hooks/useObjetosForm';
import { ObjetosEmpty } from '../../../Models/Objetos'; 
import { ObjetosForm } from '../Forms/Objetos';
 
const ObjetosInc: React.FC<IObjetosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const objetosService = new ObjetosService(
    new ObjetosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadObjetos } = useObjetosForm(
    ObjetosEmpty(),
    objetosService
  );

  useEffect(() => {
    loadObjetos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedObjetos = await objetosService.saveObjetos(data);

      if (savedObjetos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/objetos');
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
      <ObjetosForm
        objetosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ObjetosInc;
