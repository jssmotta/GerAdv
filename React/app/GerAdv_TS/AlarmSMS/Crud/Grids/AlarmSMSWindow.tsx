// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AlarmSMSInc from '../Inc/AlarmSMS';
import { IAlarmSMS } from '../../Interfaces/interface.AlarmSMS';
import { useIsMobile } from '@/app/context/MobileContext';
import { AlarmSMSEmpty } from '@/app/GerAdv_TS/Models/AlarmSMS';
import { useWindow } from '@/app/hooks/useWindows';
interface AlarmSMSWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAlarmSMS?: IAlarmSMS;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AlarmSMSWindow: React.FC<AlarmSMSWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAlarmSMS, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Alarm S M S'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={650}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedAlarmSMS?.id ?? 0).toString()}
>
<AlarmSMSInc
id={selectedAlarmSMS?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAlarmSMS: React.FC<AlarmSMSWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AlarmSMSWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAlarmSMS={AlarmSMSEmpty()}>
</AlarmSMSWindow>
)
};
export default AlarmSMSWindow;