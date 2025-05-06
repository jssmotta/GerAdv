"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { CidadeApi } from '../../Apis/ApiCidade';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ICidadeFormProps } from '../../Interfaces/interface.Cidade';
import { CidadeService } from '../../Services/Cidade.service';
import { useCidadeForm } from '../../Hooks/useCidadeForm';
import { CidadeEmpty } from '../../../Models/Cidade'; 
import { CidadeForm } from '../Forms/Cidade';
 
const CidadeInc: React.FC<ICidadeFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const cidadeService = new CidadeService(
    new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadCidade } = useCidadeForm(
    CidadeEmpty(),
    cidadeService
  );

  useEffect(() => {
    loadCidade(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedCidade = await cidadeService.saveCidade(data);

      if (savedCidade.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/cidade');
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
      <CidadeForm
        cidadeData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default CidadeInc;
