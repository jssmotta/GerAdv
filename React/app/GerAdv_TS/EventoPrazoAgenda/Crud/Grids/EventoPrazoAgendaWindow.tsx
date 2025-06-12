// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import EventoPrazoAgendaInc from '../Inc/EventoPrazoAgenda';
import { IEventoPrazoAgenda } from '../../Interfaces/interface.EventoPrazoAgenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { EventoPrazoAgendaEmpty } from '@/app/GerAdv_TS/Models/EventoPrazoAgenda';
import { useWindow } from '@/app/hooks/useWindows';
interface EventoPrazoAgendaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedEventoPrazoAgenda?: IEventoPrazoAgenda;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const EventoPrazoAgendaWindow: React.FC<EventoPrazoAgendaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedEventoPrazoAgenda, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Evento Prazo Agenda'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedEventoPrazoAgenda?.id ?? 0).toString()}
>
<EventoPrazoAgendaInc
id={selectedEventoPrazoAgenda?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowEventoPrazoAgenda: React.FC<EventoPrazoAgendaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<EventoPrazoAgendaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedEventoPrazoAgenda={EventoPrazoAgendaEmpty()}>
</EventoPrazoAgendaWindow>
)
};
export default EventoPrazoAgendaWindow;