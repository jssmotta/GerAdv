"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { FuncionariosApi } from '../../Apis/ApiFuncionarios';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IFuncionariosFormProps } from '../../Interfaces/interface.Funcionarios';
import { FuncionariosService } from '../../Services/Funcionarios.service';
import { useFuncionariosForm } from '../../Hooks/useFuncionariosForm';
import { FuncionariosEmpty } from '../../../Models/Funcionarios'; 
import { FuncionariosForm } from '../Forms/Funcionarios';
 
const FuncionariosInc: React.FC<IFuncionariosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const funcionariosService = new FuncionariosService(
    new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadFuncionarios } = useFuncionariosForm(
    FuncionariosEmpty(),
    funcionariosService
  );

  useEffect(() => {
    loadFuncionarios(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedFuncionarios = await funcionariosService.saveFuncionarios(data);

      if (savedFuncionarios.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/funcionarios');
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
      <FuncionariosForm
        funcionariosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default FuncionariosInc;
