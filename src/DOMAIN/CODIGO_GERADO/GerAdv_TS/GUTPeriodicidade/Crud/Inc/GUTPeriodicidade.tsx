"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GUTPeriodicidadeApi } from '../../Apis/ApiGUTPeriodicidade';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IGUTPeriodicidadeFormProps } from '../../Interfaces/interface.GUTPeriodicidade';
import { GUTPeriodicidadeService } from '../../Services/GUTPeriodicidade.service';
import { useGUTPeriodicidadeForm } from '../../Hooks/useGUTPeriodicidadeForm';
import { GUTPeriodicidadeEmpty } from '../../../Models/GUTPeriodicidade'; 
import { GUTPeriodicidadeForm } from '../Forms/GUTPeriodicidade';
 
const GUTPeriodicidadeInc: React.FC<IGUTPeriodicidadeFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gutperiodicidadeService = new GUTPeriodicidadeService(
    new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGUTPeriodicidade } = useGUTPeriodicidadeForm(
    GUTPeriodicidadeEmpty(),
    gutperiodicidadeService
  );

  useEffect(() => {
    loadGUTPeriodicidade(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGUTPeriodicidade = await gutperiodicidadeService.saveGUTPeriodicidade(data);

      if (savedGUTPeriodicidade.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gutperiodicidade');
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
      <GUTPeriodicidadeForm
        gutperiodicidadeData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GUTPeriodicidadeInc;
