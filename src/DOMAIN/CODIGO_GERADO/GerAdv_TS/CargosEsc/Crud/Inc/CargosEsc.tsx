"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { CargosEscApi } from '../../Apis/ApiCargosEsc';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ICargosEscFormProps } from '../../Interfaces/interface.CargosEsc';
import { CargosEscService } from '../../Services/CargosEsc.service';
import { useCargosEscForm } from '../../Hooks/useCargosEscForm';
import { CargosEscEmpty } from '../../../Models/CargosEsc'; 
import { CargosEscForm } from '../Forms/CargosEsc';
 
const CargosEscInc: React.FC<ICargosEscFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const cargosescService = new CargosEscService(
    new CargosEscApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadCargosEsc } = useCargosEscForm(
    CargosEscEmpty(),
    cargosescService
  );

  useEffect(() => {
    loadCargosEsc(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedCargosEsc = await cargosescService.saveCargosEsc(data);

      if (savedCargosEsc.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/cargosesc');
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
      <CargosEscForm
        cargosescData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default CargosEscInc;
