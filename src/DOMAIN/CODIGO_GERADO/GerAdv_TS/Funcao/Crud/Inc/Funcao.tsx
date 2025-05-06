"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { FuncaoApi } from '../../Apis/ApiFuncao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IFuncaoFormProps } from '../../Interfaces/interface.Funcao';
import { FuncaoService } from '../../Services/Funcao.service';
import { useFuncaoForm } from '../../Hooks/useFuncaoForm';
import { FuncaoEmpty } from '../../../Models/Funcao'; 
import { FuncaoForm } from '../Forms/Funcao';
 
const FuncaoInc: React.FC<IFuncaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const funcaoService = new FuncaoService(
    new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadFuncao } = useFuncaoForm(
    FuncaoEmpty(),
    funcaoService
  );

  useEffect(() => {
    loadFuncao(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedFuncao = await funcaoService.saveFuncao(data);

      if (savedFuncao.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/funcao');
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
      <FuncaoForm
        funcaoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default FuncaoInc;
