// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import OperadorGruposAgendaInc from '../Inc/OperadorGruposAgenda';
import { IOperadorGruposAgenda } from '../../Interfaces/interface.OperadorGruposAgenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { OperadorGruposAgendaEmpty } from '@/app/GerAdv_TS/Models/OperadorGruposAgenda';
import { useWindow } from '@/app/hooks/useWindows';
interface OperadorGruposAgendaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedOperadorGruposAgenda?: IOperadorGruposAgenda;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OperadorGruposAgendaWindow: React.FC<OperadorGruposAgendaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedOperadorGruposAgenda, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Operador Grupos Agenda'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedOperadorGruposAgenda?.id ?? 0).toString()}
>
<OperadorGruposAgendaInc
id={selectedOperadorGruposAgenda?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowOperadorGruposAgenda: React.FC<OperadorGruposAgendaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<OperadorGruposAgendaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedOperadorGruposAgenda={OperadorGruposAgendaEmpty()}>
</OperadorGruposAgendaWindow>
)
};
export default OperadorGruposAgendaWindow;