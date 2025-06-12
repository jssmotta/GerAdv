// Tracking: CrudInc.tsx.txt
'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { AnexamentoRegistrosApi } from '../../Apis/ApiAnexamentoRegistros';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/Cruds/NotificationComponent';
import { IAnexamentoRegistrosFormProps } from '../../Interfaces/interface.AnexamentoRegistros';
import { AnexamentoRegistrosService } from '../../Services/AnexamentoRegistros.service';
import { useAnexamentoRegistrosForm, useValidationsAnexamentoRegistros } from '../../Hooks/hookAnexamentoRegistros';
import { AnexamentoRegistrosEmpty } from '../../../Models/AnexamentoRegistros';
import { AnexamentoRegistrosForm } from '../Forms/AnexamentoRegistros';

const AnexamentoRegistrosInc: React.FC<IAnexamentoRegistrosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();
  const anexamentoregistrosService = new AnexamentoRegistrosService(
  new AnexamentoRegistrosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const notificationService = new NotificationService();
const { data, handleChange, loadAnexamentoRegistros } = useAnexamentoRegistrosForm(
AnexamentoRegistrosEmpty(), 
anexamentoregistrosService
);
useEffect(() => {
  loadAnexamentoRegistros(id);
}, [id]);

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  try {
    const savedAnexamentoRegistros = await anexamentoregistrosService.saveAnexamentoRegistros(data);
    if (savedAnexamentoRegistros.id) {
      notificationService.showNotification('Registro salvo com sucesso!', 'success');
      const PDelayApiWrite = 333;
      setTimeout(() => {
        if (onSuccess) {
          onSuccess(savedAnexamentoRegistros);
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
  loadAnexamentoRegistros(id);
};
return (
<>
<NotificationComponent notificationService={notificationService} />
<AnexamentoRegistrosForm
anexamentoregistrosData={data}
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
export default AnexamentoRegistrosInc;