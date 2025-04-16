"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ViaRecebimentoApi } from '../../Apis/ApiViaRecebimento';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IViaRecebimentoFormProps } from '../../Interfaces/interface.ViaRecebimento';
import { ViaRecebimentoService } from '../../Services/ViaRecebimento.service';
import { useViaRecebimentoForm } from '../../Hooks/useViaRecebimentoForm';
import { ViaRecebimentoEmpty } from '../../../Models/ViaRecebimento'; 
import { ViaRecebimentoForm } from '../Forms/ViaRecebimento';
 
const ViaRecebimentoInc: React.FC<IViaRecebimentoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const viarecebimentoService = new ViaRecebimentoService(
    new ViaRecebimentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadViaRecebimento } = useViaRecebimentoForm(
    ViaRecebimentoEmpty(),
    viarecebimentoService
  );

  useEffect(() => {
    loadViaRecebimento(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedViaRecebimento = await viarecebimentoService.saveViaRecebimento(data);

      if (savedViaRecebimento.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/viarecebimento');
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
      <ViaRecebimentoForm
        viarecebimentoData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ViaRecebimentoInc;
