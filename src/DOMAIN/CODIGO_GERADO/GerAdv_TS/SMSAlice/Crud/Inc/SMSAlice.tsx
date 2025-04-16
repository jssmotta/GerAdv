"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { SMSAliceApi } from '../../Apis/ApiSMSAlice';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ISMSAliceFormProps } from '../../Interfaces/interface.SMSAlice';
import { SMSAliceService } from '../../Services/SMSAlice.service';
import { useSMSAliceForm } from '../../Hooks/useSMSAliceForm';
import { SMSAliceEmpty } from '../../../Models/SMSAlice'; 
import { SMSAliceForm } from '../Forms/SMSAlice';
 
const SMSAliceInc: React.FC<ISMSAliceFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const smsaliceService = new SMSAliceService(
    new SMSAliceApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadSMSAlice } = useSMSAliceForm(
    SMSAliceEmpty(),
    smsaliceService
  );

  useEffect(() => {
    loadSMSAlice(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedSMSAlice = await smsaliceService.saveSMSAlice(data);

      if (savedSMSAlice.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/smsalice');
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
      <SMSAliceForm
        smsaliceData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default SMSAliceInc;
