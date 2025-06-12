// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ContatoCRMApi } from '../../Apis/ApiContatoCRM';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IContatoCRMFormProps } from '../../Interfaces/interface.ContatoCRM';
import { ContatoCRMService } from '../../Services/ContatoCRM.service';
import { useContatoCRMForm, useValidationsContatoCRM } from '../../Hooks/hookContatoCRM';
import { ContatoCRMEmpty } from '../../../Models/ContatoCRM';
import { ContatoCRMForm } from '../Forms/ContatoCRM';

const ContatoCRMInc: React.FC<IContatoCRMFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const contatocrmService = new ContatoCRMService(
  new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadContatoCRM } = useContatoCRMForm(
ContatoCRMEmpty(), 
contatocrmService
);
useEffect(() => {
  loadContatoCRM(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedContatoCRM = await contatocrmService.saveContatoCRM(data);
    if (savedContatoCRM.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedContatoCRM);
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
  loadContatoCRM(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<ContatoCRMForm
contatocrmData={data}
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
export default ContatoCRMInc;