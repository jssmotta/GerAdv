﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TipoEnderecoApi } from '../../Apis/ApiTipoEndereco';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { ITipoEnderecoFormProps } from '../../Interfaces/interface.TipoEndereco';
import { TipoEnderecoService } from '../../Services/TipoEndereco.service';
import { useTipoEnderecoForm } from '../../Hooks/useTipoEnderecoForm';
import { TipoEnderecoEmpty } from '../../../Models/TipoEndereco'; 
import { TipoEnderecoForm } from '../Forms/TipoEndereco';
 
const TipoEnderecoInc: React.FC<ITipoEnderecoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const tipoenderecoService = new TipoEnderecoService(
    new TipoEnderecoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadTipoEndereco } = useTipoEnderecoForm(
    TipoEnderecoEmpty(),
    tipoenderecoService
  );

  useEffect(() => {
    loadTipoEndereco(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedTipoEndereco = await tipoenderecoService.saveTipoEndereco(data);

      if (savedTipoEndereco.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/tipoendereco');
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
      <TipoEnderecoForm
        tipoenderecoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default TipoEnderecoInc;
