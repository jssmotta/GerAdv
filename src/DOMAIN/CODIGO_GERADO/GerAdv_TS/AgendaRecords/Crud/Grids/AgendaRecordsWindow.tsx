// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AgendaRecordsInc from '../Inc/AgendaRecords';
import { IAgendaRecords } from '../../Interfaces/interface.AgendaRecords';
import { useIsMobile } from '@/app/context/MobileContext';
import { AgendaRecordsEmpty } from '@/app/GerAdv_TS/Models/AgendaRecords';
import { useWindow } from '@/app/hooks/useWindows';
interface AgendaRecordsWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAgendaRecords?: IAgendaRecords;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AgendaRecordsWindow: React.FC<AgendaRecordsWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAgendaRecords, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Agenda Records'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={653}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedAgendaRecords?.id ?? 0).toString()}
>
<AgendaRecordsInc
id={selectedAgendaRecords?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAgendaRecords: React.FC<AgendaRecordsWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AgendaRecordsWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAgendaRecords={AgendaRecordsEmpty()}>
</AgendaRecordsWindow>
)
};
export default AgendaRecordsWindow;