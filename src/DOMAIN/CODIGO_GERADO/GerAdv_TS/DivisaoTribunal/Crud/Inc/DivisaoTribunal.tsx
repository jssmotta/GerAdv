"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { DivisaoTribunalApi } from '../../Apis/ApiDivisaoTribunal';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IDivisaoTribunalFormProps } from '../../Interfaces/interface.DivisaoTribunal';
import { DivisaoTribunalService } from '../../Services/DivisaoTribunal.service';
import { useDivisaoTribunalForm } from '../../Hooks/useDivisaoTribunalForm';
import { DivisaoTribunalEmpty } from '../../../Models/DivisaoTribunal'; 
import { DivisaoTribunalForm } from '../Forms/DivisaoTribunal';
 
const DivisaoTribunalInc: React.FC<IDivisaoTribunalFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const divisaotribunalService = new DivisaoTribunalService(
    new DivisaoTribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadDivisaoTribunal } = useDivisaoTribunalForm(
    DivisaoTribunalEmpty(),
    divisaotribunalService
  );

  useEffect(() => {
    loadDivisaoTribunal(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedDivisaoTribunal = await divisaotribunalService.saveDivisaoTribunal(data);

      if (savedDivisaoTribunal.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/divisaotribunal');
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
      <DivisaoTribunalForm
        divisaotribunalData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default DivisaoTribunalInc;
