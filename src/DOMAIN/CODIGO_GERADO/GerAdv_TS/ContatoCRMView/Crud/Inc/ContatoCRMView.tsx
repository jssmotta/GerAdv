// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ContatoCRMViewApi } from '../../Apis/ApiContatoCRMView';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IContatoCRMViewFormProps } from '../../Interfaces/interface.ContatoCRMView';
import { ContatoCRMViewService } from '../../Services/ContatoCRMView.service';
import { useContatoCRMViewForm, useValidationsContatoCRMView } from '../../Hooks/hookContatoCRMView';
import { ContatoCRMViewEmpty } from '../../../Models/ContatoCRMView';
import { ContatoCRMViewForm } from '../Forms/ContatoCRMView';

const ContatoCRMViewInc: React.FC<IContatoCRMViewFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const contatocrmviewService = new ContatoCRMViewService(
  new ContatoCRMViewApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadContatoCRMView } = useContatoCRMViewForm(
ContatoCRMViewEmpty(), 
contatocrmviewService
);
useEffect(() => {
  loadContatoCRMView(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedContatoCRMView = await contatocrmviewService.saveContatoCRMView(data);
    if (savedContatoCRMView.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedContatoCRMView);
        }
      }, PDelayApiWrite);
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
const handleReload = () => {
  loadContatoCRMView(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<ContatoCRMViewForm
contatocrmviewData={data}
onChange={handleChange}
onSubmit={handleSubmit}
onClose={onClose}
onError={onError}
onReload={handleReload}
onSuccess={onSuccess}
/>
</>
);
};
export default ContatoCRMViewInc;