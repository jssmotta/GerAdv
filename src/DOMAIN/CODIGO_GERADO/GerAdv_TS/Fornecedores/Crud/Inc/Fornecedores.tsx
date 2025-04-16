"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { FornecedoresApi } from '../../Apis/ApiFornecedores';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IFornecedoresFormProps } from '../../Interfaces/interface.Fornecedores';
import { FornecedoresService } from '../../Services/Fornecedores.service';
import { useFornecedoresForm } from '../../Hooks/useFornecedoresForm';
import { FornecedoresEmpty } from '../../../Models/Fornecedores'; 
import { FornecedoresForm } from '../Forms/Fornecedores';
 
const FornecedoresInc: React.FC<IFornecedoresFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const fornecedoresService = new FornecedoresService(
    new FornecedoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadFornecedores } = useFornecedoresForm(
    FornecedoresEmpty(),
    fornecedoresService
  );

  useEffect(() => {
    loadFornecedores(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedFornecedores = await fornecedoresService.saveFornecedores(data);

      if (savedFornecedores.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/fornecedores');
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
      <FornecedoresForm
        fornecedoresData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default FornecedoresInc;
