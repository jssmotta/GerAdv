// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import Agenda2AgendaInc from '../Inc/Agenda2Agenda';
import { IAgenda2Agenda } from '../../Interfaces/interface.Agenda2Agenda';
import { useIsMobile } from '@/app/context/MobileContext';
import { Agenda2AgendaEmpty } from '@/app/GerAdv_TS/Models/Agenda2Agenda';
import { useWindow } from '@/app/hooks/useWindows';
interface Agenda2AgendaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAgenda2Agenda?: IAgenda2Agenda;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const Agenda2AgendaWindow: React.FC<Agenda2AgendaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAgenda2Agenda, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Agenda2 Agenda'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedAgenda2Agenda?.id ?? 0).toString()}
>
<Agenda2AgendaInc
id={selectedAgenda2Agenda?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAgenda2Agenda: React.FC<Agenda2AgendaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<Agenda2AgendaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAgenda2Agenda={Agenda2AgendaEmpty()}>
</Agenda2AgendaWindow>
)
};
export default Agenda2AgendaWindow;