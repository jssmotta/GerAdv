// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AgendaInc from '../Inc/Agenda';
import { IAgenda } from '../../Interfaces/interface.Agenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { AgendaEmpty } from '@/app/GerAdv_TS/Models/Agenda';
import { useWindow } from '@/app/hooks/useWindows';
interface AgendaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAgenda?: IAgenda;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AgendaWindow: React.FC<AgendaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAgenda, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Agenda'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={905}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedAgenda?.id ?? 0).toString()}
>
<AgendaInc
id={selectedAgenda?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAgenda: React.FC<AgendaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AgendaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAgenda={AgendaEmpty()}>
</AgendaWindow>
)
};
export default AgendaWindow;