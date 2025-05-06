"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { HonorariosDadosContratoApi } from '../../Apis/ApiHonorariosDadosContrato';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IHonorariosDadosContratoFormProps } from '../../Interfaces/interface.HonorariosDadosContrato';
import { HonorariosDadosContratoService } from '../../Services/HonorariosDadosContrato.service';
import { useHonorariosDadosContratoForm } from '../../Hooks/useHonorariosDadosContratoForm';
import { HonorariosDadosContratoEmpty } from '../../../Models/HonorariosDadosContrato'; 
import { HonorariosDadosContratoForm } from '../Forms/HonorariosDadosContrato';
 
const HonorariosDadosContratoInc: React.FC<IHonorariosDadosContratoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const honorariosdadoscontratoService = new HonorariosDadosContratoService(
    new HonorariosDadosContratoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadHonorariosDadosContrato } = useHonorariosDadosContratoForm(
    HonorariosDadosContratoEmpty(),
    honorariosdadoscontratoService
  );

  useEffect(() => {
    loadHonorariosDadosContrato(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedHonorariosDadosContrato = await honorariosdadoscontratoService.saveHonorariosDadosContrato(data);

      if (savedHonorariosDadosContrato.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/honorariosdadoscontrato');
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
      <HonorariosDadosContratoForm
        honorariosdadoscontratoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default HonorariosDadosContratoInc;
