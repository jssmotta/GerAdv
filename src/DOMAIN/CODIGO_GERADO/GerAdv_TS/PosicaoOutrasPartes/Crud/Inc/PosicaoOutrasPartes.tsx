"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PosicaoOutrasPartesApi } from '../../Apis/ApiPosicaoOutrasPartes';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IPosicaoOutrasPartesFormProps } from '../../Interfaces/interface.PosicaoOutrasPartes';
import { PosicaoOutrasPartesService } from '../../Services/PosicaoOutrasPartes.service';
import { usePosicaoOutrasPartesForm } from '../../Hooks/usePosicaoOutrasPartesForm';
import { PosicaoOutrasPartesEmpty } from '../../../Models/PosicaoOutrasPartes'; 
import { PosicaoOutrasPartesForm } from '../Forms/PosicaoOutrasPartes';
 
const PosicaoOutrasPartesInc: React.FC<IPosicaoOutrasPartesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const posicaooutraspartesService = new PosicaoOutrasPartesService(
    new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadPosicaoOutrasPartes } = usePosicaoOutrasPartesForm(
    PosicaoOutrasPartesEmpty(),
    posicaooutraspartesService
  );

  useEffect(() => {
    loadPosicaoOutrasPartes(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedPosicaoOutrasPartes = await posicaooutraspartesService.savePosicaoOutrasPartes(data);

      if (savedPosicaoOutrasPartes.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/posicaooutraspartes');
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
      <PosicaoOutrasPartesForm
        posicaooutraspartesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default PosicaoOutrasPartesInc;
