"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoEMailApi } from '../../Apis/ApiTipoEMail';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ITipoEMailFormProps } from '../../Interfaces/interface.TipoEMail';
import { TipoEMailService } from '../../Services/TipoEMail.service';
import { useTipoEMailForm } from '../../Hooks/useTipoEMailForm';
import { TipoEMailEmpty } from '../../../Models/TipoEMail'; 
import { TipoEMailForm } from '../Forms/TipoEMail';
 
const TipoEMailInc: React.FC<ITipoEMailFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipoemailService = new TipoEMailService(
    new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoEMail } = useTipoEMailForm(
    TipoEMailEmpty(),
    tipoemailService
  );

  useEffect(() => {
    loadTipoEMail(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoEMail = await tipoemailService.saveTipoEMail(data);

      if (savedTipoEMail.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipoemail');
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
      <TipoEMailForm
        tipoemailData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoEMailInc;
