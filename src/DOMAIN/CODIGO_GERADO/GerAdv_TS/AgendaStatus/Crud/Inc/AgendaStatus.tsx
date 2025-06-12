// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaStatusApi } from '../../Apis/ApiAgendaStatus';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAgendaStatusFormProps } from '../../Interfaces/interface.AgendaStatus';
import { AgendaStatusService } from '../../Services/AgendaStatus.service';
import { useAgendaStatusForm, useValidationsAgendaStatus } from '../../Hooks/hookAgendaStatus';
import { AgendaStatusEmpty } from '../../../Models/AgendaStatus';
import { AgendaStatusForm } from '../Forms/AgendaStatus';

const AgendaStatusInc: React.FC<IAgendaStatusFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const agendastatusService = new AgendaStatusService(
  new AgendaStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadAgendaStatus } = useAgendaStatusForm(
AgendaStatusEmpty(), 
agendastatusService
);
useEffect(() => {
  loadAgendaStatus(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedAgendaStatus = await agendastatusService.saveAgendaStatus(data);
    if (savedAgendaStatus.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedAgendaStatus);
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
  loadAgendaStatus(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<AgendaStatusForm
agendastatusData={data}
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
export default AgendaStatusInc;