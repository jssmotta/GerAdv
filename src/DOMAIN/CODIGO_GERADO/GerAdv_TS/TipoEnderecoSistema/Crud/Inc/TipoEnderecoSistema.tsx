"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoEnderecoSistemaApi } from '../../Apis/ApiTipoEnderecoSistema';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoEnderecoSistemaFormProps } from '../../Interfaces/interface.TipoEnderecoSistema';
import { TipoEnderecoSistemaService } from '../../Services/TipoEnderecoSistema.service';
import { useTipoEnderecoSistemaForm } from '../../Hooks/useTipoEnderecoSistemaForm';
import { TipoEnderecoSistemaEmpty } from '../../../Models/TipoEnderecoSistema'; 
import { TipoEnderecoSistemaForm } from '../Forms/TipoEnderecoSistema';
 
const TipoEnderecoSistemaInc: React.FC<ITipoEnderecoSistemaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipoenderecosistemaService = new TipoEnderecoSistemaService(
    new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoEnderecoSistema } = useTipoEnderecoSistemaForm(
    TipoEnderecoSistemaEmpty(),
    tipoenderecosistemaService
  );

  useEffect(() => {
    loadTipoEnderecoSistema(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoEnderecoSistema = await tipoenderecosistemaService.saveTipoEnderecoSistema(data);

      if (savedTipoEnderecoSistema.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipoenderecosistema');
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
      <TipoEnderecoSistemaForm
        tipoenderecosistemaData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoEnderecoSistemaInc;
