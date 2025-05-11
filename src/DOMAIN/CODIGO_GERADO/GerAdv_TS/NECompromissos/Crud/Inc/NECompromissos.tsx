"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { NECompromissosApi } from '../../Apis/ApiNECompromissos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { INECompromissosFormProps } from '../../Interfaces/interface.NECompromissos';
import { NECompromissosService } from '../../Services/NECompromissos.service';
import { useNECompromissosForm } from '../../Hooks/useNECompromissosForm';
import { NECompromissosEmpty } from '../../../Models/NECompromissos'; 
import { NECompromissosForm } from '../Forms/NECompromissos';
 
const NECompromissosInc: React.FC<INECompromissosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const necompromissosService = new NECompromissosService(
    new NECompromissosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadNECompromissos } = useNECompromissosForm(
    NECompromissosEmpty(),
    necompromissosService
  );

  useEffect(() => {
    loadNECompromissos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedNECompromissos = await necompromissosService.saveNECompromissos(data);

      if (savedNECompromissos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/necompromissos');
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
      <NECompromissosForm
        necompromissosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default NECompromissosInc;
