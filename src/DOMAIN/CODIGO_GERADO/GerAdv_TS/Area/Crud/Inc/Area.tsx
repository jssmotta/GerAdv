"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AreaApi } from '../../Apis/ApiArea';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAreaFormProps } from '../../Interfaces/interface.Area';
import { AreaService } from '../../Services/Area.service';
import { useAreaForm } from '../../Hooks/useAreaForm';
import { AreaEmpty } from '../../../Models/Area'; 
import { AreaForm } from '../Forms/Area';
 
const AreaInc: React.FC<IAreaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const areaService = new AreaService(
    new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadArea } = useAreaForm(
    AreaEmpty(),
    areaService
  );

  useEffect(() => {
    loadArea(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedArea = await areaService.saveArea(data);

      if (savedArea.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/area');
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
      <AreaForm
        areaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AreaInc;
