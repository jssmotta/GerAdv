// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { OperadoresApi } from '../../Apis/ApiOperadores';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IOperadoresFormProps } from '../../Interfaces/interface.Operadores';
import { OperadoresService } from '../../Services/Operadores.service';
import { useOperadoresForm, useValidationsOperadores } from '../../Hooks/hookOperadores';
import { OperadoresEmpty } from '../../../Models/Operadores';
import { OperadoresForm } from '../Forms/Operadores';

const OperadoresInc: React.FC<IOperadoresFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const operadoresService = new OperadoresService(
  new OperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadOperadores } = useOperadoresForm(
OperadoresEmpty(), 
operadoresService
);
useEffect(() => {
  loadOperadores(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedOperadores = await operadoresService.saveOperadores(data);
    if (savedOperadores.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedOperadores);
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
  loadOperadores(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<OperadoresForm
operadoresData={data}
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
export default OperadoresInc;