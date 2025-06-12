// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ParteClienteOutrasApi } from '../../Apis/ApiParteClienteOutras';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IParteClienteOutrasFormProps } from '../../Interfaces/interface.ParteClienteOutras';
import { ParteClienteOutrasService } from '../../Services/ParteClienteOutras.service';
import { useParteClienteOutrasForm, useValidationsParteClienteOutras } from '../../Hooks/hookParteClienteOutras';
import { ParteClienteOutrasEmpty } from '../../../Models/ParteClienteOutras';
import { ParteClienteOutrasForm } from '../Forms/ParteClienteOutras';

const ParteClienteOutrasInc: React.FC<IParteClienteOutrasFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const parteclienteoutrasService = new ParteClienteOutrasService(
  new ParteClienteOutrasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadParteClienteOutras } = useParteClienteOutrasForm(
ParteClienteOutrasEmpty(), 
parteclienteoutrasService
);
useEffect(() => {
  loadParteClienteOutras(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedParteClienteOutras = await parteclienteoutrasService.saveParteClienteOutras(data);
    if (savedParteClienteOutras.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedParteClienteOutras);
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
  loadParteClienteOutras(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<ParteClienteOutrasForm
parteclienteoutrasData={data}
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
export default ParteClienteOutrasInc;