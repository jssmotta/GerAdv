// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { StatusBiuApi } from '../../Apis/ApiStatusBiu';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IStatusBiuFormProps } from '../../Interfaces/interface.StatusBiu';
import { StatusBiuService } from '../../Services/StatusBiu.service';
import { useStatusBiuForm, useValidationsStatusBiu } from '../../Hooks/hookStatusBiu';
import { StatusBiuEmpty } from '../../../Models/StatusBiu';
import { StatusBiuForm } from '../Forms/StatusBiu';

const StatusBiuInc: React.FC<IStatusBiuFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const statusbiuService = new StatusBiuService(
  new StatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadStatusBiu } = useStatusBiuForm(
StatusBiuEmpty(), 
statusbiuService
);
useEffect(() => {
  loadStatusBiu(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedStatusBiu = await statusbiuService.saveStatusBiu(data);
    if (savedStatusBiu.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedStatusBiu);
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
  loadStatusBiu(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<StatusBiuForm
statusbiuData={data}
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
export default StatusBiuInc;