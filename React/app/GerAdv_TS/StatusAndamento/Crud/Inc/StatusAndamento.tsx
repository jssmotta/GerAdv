// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { StatusAndamentoApi } from '../../Apis/ApiStatusAndamento';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IStatusAndamentoFormProps } from '../../Interfaces/interface.StatusAndamento';
import { StatusAndamentoService } from '../../Services/StatusAndamento.service';
import { useStatusAndamentoForm, useValidationsStatusAndamento } from '../../Hooks/hookStatusAndamento';
import { StatusAndamentoEmpty } from '../../../Models/StatusAndamento';
import { StatusAndamentoForm } from '../Forms/StatusAndamento';

const StatusAndamentoInc: React.FC<IStatusAndamentoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const statusandamentoService = new StatusAndamentoService(
  new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadStatusAndamento } = useStatusAndamentoForm(
StatusAndamentoEmpty(), 
statusandamentoService
);
useEffect(() => {
  loadStatusAndamento(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedStatusAndamento = await statusandamentoService.saveStatusAndamento(data);
    if (savedStatusAndamento.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedStatusAndamento);
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
  loadStatusAndamento(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<StatusAndamentoForm
statusandamentoData={data}
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
export default StatusAndamentoInc;