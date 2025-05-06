"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadorEMailPopupApi } from '../../Apis/ApiOperadorEMailPopup';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IOperadorEMailPopupFormProps } from '../../Interfaces/interface.OperadorEMailPopup';
import { OperadorEMailPopupService } from '../../Services/OperadorEMailPopup.service';
import { useOperadorEMailPopupForm } from '../../Hooks/useOperadorEMailPopupForm';
import { OperadorEMailPopupEmpty } from '../../../Models/OperadorEMailPopup'; 
import { OperadorEMailPopupForm } from '../Forms/OperadorEMailPopup';
 
const OperadorEMailPopupInc: React.FC<IOperadorEMailPopupFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const operadoremailpopupService = new OperadorEMailPopupService(
    new OperadorEMailPopupApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOperadorEMailPopup } = useOperadorEMailPopupForm(
    OperadorEMailPopupEmpty(),
    operadoremailpopupService
  );

  useEffect(() => {
    loadOperadorEMailPopup(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOperadorEMailPopup = await operadoremailpopupService.saveOperadorEMailPopup(data);

      if (savedOperadorEMailPopup.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/operadoremailpopup');
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
      <OperadorEMailPopupForm
        operadoremailpopupData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OperadorEMailPopupInc;
