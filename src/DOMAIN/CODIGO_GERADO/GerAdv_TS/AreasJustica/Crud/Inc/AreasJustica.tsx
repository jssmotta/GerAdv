"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AreasJusticaApi } from '../../Apis/ApiAreasJustica';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAreasJusticaFormProps } from '../../Interfaces/interface.AreasJustica';
import { AreasJusticaService } from '../../Services/AreasJustica.service';
import { useAreasJusticaForm } from '../../Hooks/useAreasJusticaForm';
import { AreasJusticaEmpty } from '../../../Models/AreasJustica'; 
import { AreasJusticaForm } from '../Forms/AreasJustica';
 
const AreasJusticaInc: React.FC<IAreasJusticaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const areasjusticaService = new AreasJusticaService(
    new AreasJusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAreasJustica } = useAreasJusticaForm(
    AreasJusticaEmpty(),
    areasjusticaService
  );

  useEffect(() => {
    loadAreasJustica(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAreasJustica = await areasjusticaService.saveAreasJustica(data);

      if (savedAreasJustica.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/areasjustica');
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
      <AreasJusticaForm
        areasjusticaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AreasJusticaInc;
