"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { CargosEscClassApi } from '../../Apis/ApiCargosEscClass';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ICargosEscClassFormProps } from '../../Interfaces/interface.CargosEscClass';
import { CargosEscClassService } from '../../Services/CargosEscClass.service';
import { useCargosEscClassForm } from '../../Hooks/useCargosEscClassForm';
import { CargosEscClassEmpty } from '../../../Models/CargosEscClass'; 
import { CargosEscClassForm } from '../Forms/CargosEscClass';
 
const CargosEscClassInc: React.FC<ICargosEscClassFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const cargosescclassService = new CargosEscClassService(
    new CargosEscClassApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadCargosEscClass } = useCargosEscClassForm(
    CargosEscClassEmpty(),
    cargosescclassService
  );

  useEffect(() => {
    loadCargosEscClass(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedCargosEscClass = await cargosescclassService.saveCargosEscClass(data);

      if (savedCargosEscClass.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/cargosescclass');
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
      <CargosEscClassForm
        cargosescclassData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default CargosEscClassInc;
