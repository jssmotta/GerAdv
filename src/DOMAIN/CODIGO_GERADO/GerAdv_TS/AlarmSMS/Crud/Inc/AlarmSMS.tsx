"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AlarmSMSApi } from '../../Apis/ApiAlarmSMS';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IAlarmSMSFormProps } from '../../Interfaces/interface.AlarmSMS';
import { AlarmSMSService } from '../../Services/AlarmSMS.service';
import { useAlarmSMSForm } from '../../Hooks/useAlarmSMSForm';
import { AlarmSMSEmpty } from '../../../Models/AlarmSMS'; 
import { AlarmSMSForm } from '../Forms/AlarmSMS';
 
const AlarmSMSInc: React.FC<IAlarmSMSFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const alarmsmsService = new AlarmSMSService(
    new AlarmSMSApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAlarmSMS } = useAlarmSMSForm(
    AlarmSMSEmpty(),
    alarmsmsService
  );

  useEffect(() => {
    loadAlarmSMS(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAlarmSMS = await alarmsmsService.saveAlarmSMS(data);

      if (savedAlarmSMS.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/alarmsms');
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
      <AlarmSMSForm
        alarmsmsData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AlarmSMSInc;
