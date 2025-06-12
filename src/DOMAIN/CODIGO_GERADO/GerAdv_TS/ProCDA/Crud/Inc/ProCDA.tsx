// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProCDAApi } from '../../Apis/ApiProCDA';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IProCDAFormProps } from '../../Interfaces/interface.ProCDA';
import { ProCDAService } from '../../Services/ProCDA.service';
import { useProCDAForm, useValidationsProCDA } from '../../Hooks/hookProCDA';
import { ProCDAEmpty } from '../../../Models/ProCDA';
import { ProCDAForm } from '../Forms/ProCDA';

const ProCDAInc: React.FC<IProCDAFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const procdaService = new ProCDAService(
  new ProCDAApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadProCDA } = useProCDAForm(
ProCDAEmpty(), 
procdaService
);
useEffect(() => {
  loadProCDA(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedProCDA = await procdaService.saveProCDA(data);
    if (savedProCDA.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedProCDA);
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
  loadProCDA(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<ProCDAForm
procdaData={data}
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
export default ProCDAInc;