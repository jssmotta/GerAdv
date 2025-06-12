// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { TerceirosApi } from '../../Apis/ApiTerceiros';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { ITerceirosFormProps } from '../../Interfaces/interface.Terceiros';
import { TerceirosService } from '../../Services/Terceiros.service';
import { useTerceirosForm, useValidationsTerceiros } from '../../Hooks/hookTerceiros';
import { TerceirosEmpty } from '../../../Models/Terceiros';
import { TerceirosForm } from '../Forms/Terceiros';

const TerceirosInc: React.FC<ITerceirosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const terceirosService = new TerceirosService(
  new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadTerceiros } = useTerceirosForm(
TerceirosEmpty(), 
terceirosService
);
useEffect(() => {
  loadTerceiros(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedTerceiros = await terceirosService.saveTerceiros(data);
    if (savedTerceiros.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedTerceiros);
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
  loadTerceiros(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<TerceirosForm
terceirosData={data}
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
export default TerceirosInc;