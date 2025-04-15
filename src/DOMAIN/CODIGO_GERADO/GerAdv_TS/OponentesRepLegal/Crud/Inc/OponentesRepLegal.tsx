"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OponentesRepLegalApi } from '../../Apis/ApiOponentesRepLegal';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IOponentesRepLegalFormProps } from '../../Interfaces/interface.OponentesRepLegal';
import { OponentesRepLegalService } from '../../Services/OponentesRepLegal.service';
import { useOponentesRepLegalForm } from '../../Hooks/useOponentesRepLegalForm';
import { OponentesRepLegalEmpty } from '../../../Models/OponentesRepLegal'; 
import { OponentesRepLegalForm } from '../Forms/OponentesRepLegal';
 
const OponentesRepLegalInc: React.FC<IOponentesRepLegalFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const oponentesreplegalService = new OponentesRepLegalService(
    new OponentesRepLegalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadOponentesRepLegal } = useOponentesRepLegalForm(
    OponentesRepLegalEmpty(),
    oponentesreplegalService
  );

  useEffect(() => {
    loadOponentesRepLegal(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedOponentesRepLegal = await oponentesreplegalService.saveOponentesRepLegal(data);

      if (savedOponentesRepLegal.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/oponentesreplegal');
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
      <OponentesRepLegalForm
        oponentesreplegalData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default OponentesRepLegalInc;
