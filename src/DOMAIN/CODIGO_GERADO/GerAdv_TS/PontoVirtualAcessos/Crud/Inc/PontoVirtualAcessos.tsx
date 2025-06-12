// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { PontoVirtualAcessosApi } from '../../Apis/ApiPontoVirtualAcessos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IPontoVirtualAcessosFormProps } from '../../Interfaces/interface.PontoVirtualAcessos';
import { PontoVirtualAcessosService } from '../../Services/PontoVirtualAcessos.service';
import { usePontoVirtualAcessosForm, useValidationsPontoVirtualAcessos } from '../../Hooks/hookPontoVirtualAcessos';
import { PontoVirtualAcessosEmpty } from '../../../Models/PontoVirtualAcessos';
import { PontoVirtualAcessosForm } from '../Forms/PontoVirtualAcessos';

const PontoVirtualAcessosInc: React.FC<IPontoVirtualAcessosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const pontovirtualacessosService = new PontoVirtualAcessosService(
  new PontoVirtualAcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadPontoVirtualAcessos } = usePontoVirtualAcessosForm(
PontoVirtualAcessosEmpty(), 
pontovirtualacessosService
);
useEffect(() => {
  loadPontoVirtualAcessos(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedPontoVirtualAcessos = await pontovirtualacessosService.savePontoVirtualAcessos(data);
    if (savedPontoVirtualAcessos.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedPontoVirtualAcessos);
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
  loadPontoVirtualAcessos(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<PontoVirtualAcessosForm
pontovirtualacessosData={data}
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
export default PontoVirtualAcessosInc;