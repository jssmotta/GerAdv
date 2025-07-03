// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AgendaRelatorioInc from '../Inc/AgendaRelatorio';
import { IAgendaRelatorio } from '../../Interfaces/interface.AgendaRelatorio';
import { useIsMobile } from '@/app/context/MobileContext';
import { AgendaRelatorioEmpty } from '@/app/GerAdv_TS/Models/AgendaRelatorio';
import { useWindow } from '@/app/hooks/useWindows';
interface AgendaRelatorioWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAgendaRelatorio?: IAgendaRelatorio;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AgendaRelatorioWindow: React.FC<AgendaRelatorioWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAgendaRelatorio, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Agenda Relatorio'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={590}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedAgendaRelatorio?.id ?? 0).toString()}
>
<AgendaRelatorioInc
id={selectedAgendaRelatorio?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAgendaRelatorio: React.FC<AgendaRelatorioWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AgendaRelatorioWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAgendaRelatorio={AgendaRelatorioEmpty()}>
</AgendaRelatorioWindow>
)
};
export default AgendaRelatorioWindow;