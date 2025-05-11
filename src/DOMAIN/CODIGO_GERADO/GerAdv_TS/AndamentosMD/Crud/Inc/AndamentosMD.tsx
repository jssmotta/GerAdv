"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AndamentosMDApi } from '../../Apis/ApiAndamentosMD';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAndamentosMDFormProps } from '../../Interfaces/interface.AndamentosMD';
import { AndamentosMDService } from '../../Services/AndamentosMD.service';
import { useAndamentosMDForm } from '../../Hooks/useAndamentosMDForm';
import { AndamentosMDEmpty } from '../../../Models/AndamentosMD'; 
import { AndamentosMDForm } from '../Forms/AndamentosMD';
 
const AndamentosMDInc: React.FC<IAndamentosMDFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const andamentosmdService = new AndamentosMDService(
    new AndamentosMDApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadAndamentosMD } = useAndamentosMDForm(
    AndamentosMDEmpty(),
    andamentosmdService
  );

  useEffect(() => {
    loadAndamentosMD(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedAndamentosMD = await andamentosmdService.saveAndamentosMD(data);

      if (savedAndamentosMD.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/andamentosmd');
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
      <AndamentosMDForm
        andamentosmdData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default AndamentosMDInc;
