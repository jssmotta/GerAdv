// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { BensClassificacaoApi } from '../../Apis/ApiBensClassificacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IBensClassificacaoFormProps } from '../../Interfaces/interface.BensClassificacao';
import { BensClassificacaoService } from '../../Services/BensClassificacao.service';
import { useBensClassificacaoForm, useValidationsBensClassificacao } from '../../Hooks/hookBensClassificacao';
import { BensClassificacaoEmpty } from '../../../Models/BensClassificacao';
import { BensClassificacaoForm } from '../Forms/BensClassificacao';

const BensClassificacaoInc: React.FC<IBensClassificacaoFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const bensclassificacaoService = new BensClassificacaoService(
  new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadBensClassificacao } = useBensClassificacaoForm(
BensClassificacaoEmpty(), 
bensclassificacaoService
);
useEffect(() => {
  loadBensClassificacao(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedBensClassificacao = await bensclassificacaoService.saveBensClassificacao(data);
    if (savedBensClassificacao.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedBensClassificacao);
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
  loadBensClassificacao(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<BensClassificacaoForm
bensclassificacaoData={data}
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
export default BensClassificacaoInc;