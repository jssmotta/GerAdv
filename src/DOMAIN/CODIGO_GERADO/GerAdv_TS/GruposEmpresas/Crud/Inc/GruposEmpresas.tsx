﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GruposEmpresasApi } from '../../Apis/ApiGruposEmpresas';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IGruposEmpresasFormProps } from '../../Interfaces/interface.GruposEmpresas';
import { GruposEmpresasService } from '../../Services/GruposEmpresas.service';
import { useGruposEmpresasForm } from '../../Hooks/useGruposEmpresasForm';
import { GruposEmpresasEmpty } from '../../../Models/GruposEmpresas'; 
import { GruposEmpresasForm } from '../Forms/GruposEmpresas';
 
const GruposEmpresasInc: React.FC<IGruposEmpresasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const gruposempresasService = new GruposEmpresasService(
    new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGruposEmpresas } = useGruposEmpresasForm(
    GruposEmpresasEmpty(),
    gruposempresasService
  );

  useEffect(() => {
    loadGruposEmpresas(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGruposEmpresas = await gruposempresasService.saveGruposEmpresas(data);

      if (savedGruposEmpresas.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/gruposempresas');
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
      <GruposEmpresasForm
        gruposempresasData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GruposEmpresasInc;
