"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TribunalApi } from '../../Apis/ApiTribunal';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ITribunalFormProps } from '../../Interfaces/interface.Tribunal';
import { TribunalService } from '../../Services/Tribunal.service';
import { useTribunalForm } from '../../Hooks/useTribunalForm';
import { TribunalEmpty } from '../../../Models/Tribunal'; 
import { TribunalForm } from '../Forms/Tribunal';
 
const TribunalInc: React.FC<ITribunalFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tribunalService = new TribunalService(
    new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTribunal } = useTribunalForm(
    TribunalEmpty(),
    tribunalService
  );

  useEffect(() => {
    loadTribunal(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTribunal = await tribunalService.saveTribunal(data);

      if (savedTribunal.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tribunal');
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
      <TribunalForm
        tribunalData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TribunalInc;
