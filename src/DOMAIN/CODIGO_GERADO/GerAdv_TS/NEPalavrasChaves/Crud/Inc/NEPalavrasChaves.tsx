"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { NEPalavrasChavesApi } from '../../Apis/ApiNEPalavrasChaves';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { INEPalavrasChavesFormProps } from '../../Interfaces/interface.NEPalavrasChaves';
import { NEPalavrasChavesService } from '../../Services/NEPalavrasChaves.service';
import { useNEPalavrasChavesForm } from '../../Hooks/useNEPalavrasChavesForm';
import { NEPalavrasChavesEmpty } from '../../../Models/NEPalavrasChaves'; 
import { NEPalavrasChavesForm } from '../Forms/NEPalavrasChaves';
 
const NEPalavrasChavesInc: React.FC<INEPalavrasChavesFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const nepalavraschavesService = new NEPalavrasChavesService(
    new NEPalavrasChavesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadNEPalavrasChaves } = useNEPalavrasChavesForm(
    NEPalavrasChavesEmpty(),
    nepalavraschavesService
  );

  useEffect(() => {
    loadNEPalavrasChaves(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedNEPalavrasChaves = await nepalavraschavesService.saveNEPalavrasChaves(data);

      if (savedNEPalavrasChaves.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/nepalavraschaves');
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
      <NEPalavrasChavesForm
        nepalavraschavesData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default NEPalavrasChavesInc;
