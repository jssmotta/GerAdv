// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProDepositosApi } from '../../Apis/ApiProDepositos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IProDepositosFormProps } from '../../Interfaces/interface.ProDepositos';
import { ProDepositosService } from '../../Services/ProDepositos.service';
import { useProDepositosForm, useValidationsProDepositos } from '../../Hooks/hookProDepositos';
import { ProDepositosEmpty } from '../../../Models/ProDepositos';
import { ProDepositosForm } from '../Forms/ProDepositos';

const ProDepositosInc: React.FC<IProDepositosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const prodepositosService = new ProDepositosService(
  new ProDepositosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadProDepositos } = useProDepositosForm(
ProDepositosEmpty(), 
prodepositosService
);
useEffect(() => {
  loadProDepositos(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedProDepositos = await prodepositosService.saveProDepositos(data);
    if (savedProDepositos.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedProDepositos);
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
  loadProDepositos(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<ProDepositosForm
prodepositosData={data}
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
export default ProDepositosInc;