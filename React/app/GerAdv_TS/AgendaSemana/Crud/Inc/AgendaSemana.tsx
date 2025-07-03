// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AgendaSemanaApi } from '../../Apis/ApiAgendaSemana';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAgendaSemanaFormProps } from '../../Interfaces/interface.AgendaSemana';
import { AgendaSemanaService } from '../../Services/AgendaSemana.service';
import { useAgendaSemanaForm, useValidationsAgendaSemana } from '../../Hooks/hookAgendaSemana';
import { AgendaSemanaEmpty } from '../../../Models/AgendaSemana';
import { AgendaSemanaForm } from '../Forms/AgendaSemana';

const AgendaSemanaInc: React.FC<IAgendaSemanaFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const agendasemanaService = new AgendaSemanaService(
  new AgendaSemanaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadAgendaSemana } = useAgendaSemanaForm(
AgendaSemanaEmpty(), 
agendasemanaService
);
useEffect(() => {
  loadAgendaSemana(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedAgendaSemana = await agendasemanaService.saveAgendaSemana(data);
    if (savedAgendaSemana.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedAgendaSemana);
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
  loadAgendaSemana(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<AgendaSemanaForm
agendasemanaData={data}
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
export default AgendaSemanaInc;