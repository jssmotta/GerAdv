"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { NENotasApi } from '../../Apis/ApiNENotas';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { INENotasFormProps } from '../../Interfaces/interface.NENotas';
import { NENotasService } from '../../Services/NENotas.service';
import { useNENotasForm } from '../../Hooks/useNENotasForm';
import { NENotasEmpty } from '../../../Models/NENotas'; 
import { NENotasForm } from '../Forms/NENotas';
 
const NENotasInc: React.FC<INENotasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const nenotasService = new NENotasService(
    new NENotasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadNENotas } = useNENotasForm(
    NENotasEmpty(),
    nenotasService
  );

  useEffect(() => {
    loadNENotas(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedNENotas = await nenotasService.saveNENotas(data);

      if (savedNENotas.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/nenotas');
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
      <NENotasForm
        nenotasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default NENotasInc;
