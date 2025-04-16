"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ParceriaProcApi } from '../../Apis/ApiParceriaProc';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IParceriaProcFormProps } from '../../Interfaces/interface.ParceriaProc';
import { ParceriaProcService } from '../../Services/ParceriaProc.service';
import { useParceriaProcForm } from '../../Hooks/useParceriaProcForm';
import { ParceriaProcEmpty } from '../../../Models/ParceriaProc'; 
import { ParceriaProcForm } from '../Forms/ParceriaProc';
 
const ParceriaProcInc: React.FC<IParceriaProcFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const parceriaprocService = new ParceriaProcService(
    new ParceriaProcApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadParceriaProc } = useParceriaProcForm(
    ParceriaProcEmpty(),
    parceriaprocService
  );

  useEffect(() => {
    loadParceriaProc(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedParceriaProc = await parceriaprocService.saveParceriaProc(data);

      if (savedParceriaProc.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/parceriaproc');
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
      <ParceriaProcForm
        parceriaprocData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ParceriaProcInc;
