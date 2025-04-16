"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { DocsRecebidosItensApi } from '../../Apis/ApiDocsRecebidosItens';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IDocsRecebidosItensFormProps } from '../../Interfaces/interface.DocsRecebidosItens';
import { DocsRecebidosItensService } from '../../Services/DocsRecebidosItens.service';
import { useDocsRecebidosItensForm } from '../../Hooks/useDocsRecebidosItensForm';
import { DocsRecebidosItensEmpty } from '../../../Models/DocsRecebidosItens'; 
import { DocsRecebidosItensForm } from '../Forms/DocsRecebidosItens';
 
const DocsRecebidosItensInc: React.FC<IDocsRecebidosItensFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const docsrecebidositensService = new DocsRecebidosItensService(
    new DocsRecebidosItensApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadDocsRecebidosItens } = useDocsRecebidosItensForm(
    DocsRecebidosItensEmpty(),
    docsrecebidositensService
  );

  useEffect(() => {
    loadDocsRecebidosItens(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedDocsRecebidosItens = await docsrecebidositensService.saveDocsRecebidosItens(data);

      if (savedDocsRecebidosItens.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/docsrecebidositens');
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
      <DocsRecebidosItensForm
        docsrecebidositensData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default DocsRecebidosItensInc;
