"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { Auditor4KApi } from '../../Apis/ApiAuditor4K';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAuditor4KFormProps } from '../../Interfaces/interface.Auditor4K';
import { Auditor4KService } from '../../Services/Auditor4K.service';
import { useAuditor4KForm } from '../../Hooks/useAuditor4KForm';
import { Auditor4KEmpty } from '../../../Models/Auditor4K'; 
import { Auditor4KForm } from '../Forms/Auditor4K';
 
const Auditor4KInc: React.FC<IAuditor4KFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const auditor4kService = new Auditor4KService(
    new Auditor4KApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAuditor4K } = useAuditor4KForm(
    Auditor4KEmpty(),
    auditor4kService
  );

  useEffect(() => {
    loadAuditor4K(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAuditor4K = await auditor4kService.saveAuditor4K(data);

      if (savedAuditor4K.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/auditor4k');
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
      <Auditor4KForm
        auditor4kData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default Auditor4KInc;
