"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PontoVirtualApi } from '../../Apis/ApiPontoVirtual';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IPontoVirtualFormProps } from '../../Interfaces/interface.PontoVirtual';
import { PontoVirtualService } from '../../Services/PontoVirtual.service';
import { usePontoVirtualForm } from '../../Hooks/usePontoVirtualForm';
import { PontoVirtualEmpty } from '../../../Models/PontoVirtual'; 
import { PontoVirtualForm } from '../Forms/PontoVirtual';
 
const PontoVirtualInc: React.FC<IPontoVirtualFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const pontovirtualService = new PontoVirtualService(
    new PontoVirtualApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPontoVirtual } = usePontoVirtualForm(
    PontoVirtualEmpty(),
    pontovirtualService
  );

  useEffect(() => {
    loadPontoVirtual(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPontoVirtual = await pontovirtualService.savePontoVirtual(data);

      if (savedPontoVirtual.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/pontovirtual');
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
      <PontoVirtualForm
        pontovirtualData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PontoVirtualInc;
