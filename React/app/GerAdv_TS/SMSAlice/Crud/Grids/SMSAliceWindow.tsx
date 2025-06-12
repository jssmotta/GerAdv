// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import SMSAliceInc from '../Inc/SMSAlice';
import { ISMSAlice } from '../../Interfaces/interface.SMSAlice';
import { useIsMobile } from '@/app/context/MobileContext';
import { SMSAliceEmpty } from '@/app/GerAdv_TS/Models/SMSAlice';
import { useWindow } from '@/app/hooks/useWindows';
interface SMSAliceWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedSMSAlice?: ISMSAlice;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const SMSAliceWindow: React.FC<SMSAliceWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedSMSAlice, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='S M S Alice'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedSMSAlice?.id ?? 0).toString()}
>
<SMSAliceInc
id={selectedSMSAlice?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowSMSAlice: React.FC<SMSAliceWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<SMSAliceWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedSMSAlice={SMSAliceEmpty()}>
</SMSAliceWindow>
)
};
export default SMSAliceWindow;