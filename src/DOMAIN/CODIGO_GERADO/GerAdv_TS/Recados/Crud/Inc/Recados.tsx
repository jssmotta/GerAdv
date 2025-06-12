// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { RecadosApi } from '../../Apis/ApiRecados';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IRecadosFormProps } from '../../Interfaces/interface.Recados';
import { RecadosService } from '../../Services/Recados.service';
import { useRecadosForm, useValidationsRecados } from '../../Hooks/hookRecados';
import { RecadosEmpty } from '../../../Models/Recados';
import { RecadosForm } from '../Forms/Recados';

const RecadosInc: React.FC<IRecadosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const recadosService = new RecadosService(
  new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadRecados } = useRecadosForm(
RecadosEmpty(), 
recadosService
);
useEffect(() => {
  loadRecados(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedRecados = await recadosService.saveRecados(data);
    if (savedRecados.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedRecados);
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
  loadRecados(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<RecadosForm
recadosData={data}
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
export default RecadosInc;