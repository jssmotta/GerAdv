// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProcessOutputEngineInc from '../Inc/ProcessOutputEngine';
import { IProcessOutputEngine } from '../../Interfaces/interface.ProcessOutputEngine';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProcessOutputEngineEmpty } from '@/app/GerAdv_TS/Models/ProcessOutputEngine';
import { useWindow } from '@/app/hooks/useWindows';
interface ProcessOutputEngineWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProcessOutputEngine?: IProcessOutputEngine;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProcessOutputEngineWindow: React.FC<ProcessOutputEngineWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProcessOutputEngine, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Process Output Engine'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={563}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedProcessOutputEngine?.id ?? 0).toString()}
>
<ProcessOutputEngineInc
id={selectedProcessOutputEngine?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProcessOutputEngine: React.FC<ProcessOutputEngineWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProcessOutputEngineWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProcessOutputEngine={ProcessOutputEngineEmpty()}>
</ProcessOutputEngineWindow>
)
};
export default ProcessOutputEngineWindow;