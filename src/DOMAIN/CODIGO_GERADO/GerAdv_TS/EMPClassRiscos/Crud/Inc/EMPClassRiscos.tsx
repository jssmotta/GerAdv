"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { EMPClassRiscosApi } from '../../Apis/ApiEMPClassRiscos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IEMPClassRiscosFormProps } from '../../Interfaces/interface.EMPClassRiscos';
import { EMPClassRiscosService } from '../../Services/EMPClassRiscos.service';
import { useEMPClassRiscosForm } from '../../Hooks/useEMPClassRiscosForm';
import { EMPClassRiscosEmpty } from '../../../Models/EMPClassRiscos'; 
import { EMPClassRiscosForm } from '../Forms/EMPClassRiscos';
 
const EMPClassRiscosInc: React.FC<IEMPClassRiscosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const empclassriscosService = new EMPClassRiscosService(
    new EMPClassRiscosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadEMPClassRiscos } = useEMPClassRiscosForm(
    EMPClassRiscosEmpty(),
    empclassriscosService
  );

  useEffect(() => {
    loadEMPClassRiscos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedEMPClassRiscos = await empclassriscosService.saveEMPClassRiscos(data);

      if (savedEMPClassRiscos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/empclassriscos');
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
      <EMPClassRiscosForm
        empclassriscosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default EMPClassRiscosInc;
