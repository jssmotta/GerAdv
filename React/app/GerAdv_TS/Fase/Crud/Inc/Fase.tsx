// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { FaseApi } from '../../Apis/ApiFase';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IFaseFormProps } from '../../Interfaces/interface.Fase';
import { FaseService } from '../../Services/Fase.service';
import { useFaseForm, useValidationsFase } from '../../Hooks/hookFase';
import { FaseEmpty } from '../../../Models/Fase';
import { FaseForm } from '../Forms/Fase';

const FaseInc: React.FC<IFaseFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const faseService = new FaseService(
  new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadFase } = useFaseForm(
FaseEmpty(), 
faseService
);
useEffect(() => {
  loadFase(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedFase = await faseService.saveFase(data);
    if (savedFase.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedFase);
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
  loadFase(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<FaseForm
faseData={data}
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
export default FaseInc;