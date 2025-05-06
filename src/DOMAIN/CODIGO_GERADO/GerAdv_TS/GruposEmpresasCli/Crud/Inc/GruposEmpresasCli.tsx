"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GruposEmpresasCliApi } from '../../Apis/ApiGruposEmpresasCli';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IGruposEmpresasCliFormProps } from '../../Interfaces/interface.GruposEmpresasCli';
import { GruposEmpresasCliService } from '../../Services/GruposEmpresasCli.service';
import { useGruposEmpresasCliForm } from '../../Hooks/useGruposEmpresasCliForm';
import { GruposEmpresasCliEmpty } from '../../../Models/GruposEmpresasCli'; 
import { GruposEmpresasCliForm } from '../Forms/GruposEmpresasCli';
 
const GruposEmpresasCliInc: React.FC<IGruposEmpresasCliFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gruposempresascliService = new GruposEmpresasCliService(
    new GruposEmpresasCliApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGruposEmpresasCli } = useGruposEmpresasCliForm(
    GruposEmpresasCliEmpty(),
    gruposempresascliService
  );

  useEffect(() => {
    loadGruposEmpresasCli(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGruposEmpresasCli = await gruposempresascliService.saveGruposEmpresasCli(data);

      if (savedGruposEmpresasCli.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gruposempresascli');
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
      <GruposEmpresasCliForm
        gruposempresascliData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GruposEmpresasCliInc;
