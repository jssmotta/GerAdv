// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import StatusAndamentoInc from '../Inc/StatusAndamento';
import { IStatusAndamento } from '../../Interfaces/interface.StatusAndamento';
import { useIsMobile } from '@/app/context/MobileContext';
import { StatusAndamentoEmpty } from '@/app/GerAdv_TS/Models/StatusAndamento';
import { useWindow } from '@/app/hooks/useWindows';
interface StatusAndamentoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedStatusAndamento?: IStatusAndamento;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const StatusAndamentoWindow: React.FC<StatusAndamentoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedStatusAndamento, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Status Andamento'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedStatusAndamento?.id ?? 0).toString()}
>
<StatusAndamentoInc
id={selectedStatusAndamento?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowStatusAndamento: React.FC<StatusAndamentoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<StatusAndamentoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedStatusAndamento={StatusAndamentoEmpty()}>
</StatusAndamentoWindow>
)
};
export default StatusAndamentoWindow;