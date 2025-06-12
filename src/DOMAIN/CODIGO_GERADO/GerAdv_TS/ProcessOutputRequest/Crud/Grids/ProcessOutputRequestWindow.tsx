// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProcessOutputRequestInc from '../Inc/ProcessOutputRequest';
import { IProcessOutputRequest } from '../../Interfaces/interface.ProcessOutputRequest';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProcessOutputRequestEmpty } from '@/app/GerAdv_TS/Models/ProcessOutputRequest';
import { useWindow } from '@/app/hooks/useWindows';
interface ProcessOutputRequestWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProcessOutputRequest?: IProcessOutputRequest;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProcessOutputRequestWindow: React.FC<ProcessOutputRequestWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProcessOutputRequest, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Process Output Request'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProcessOutputRequest?.id ?? 0).toString()}
>
<ProcessOutputRequestInc
id={selectedProcessOutputRequest?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProcessOutputRequest: React.FC<ProcessOutputRequestWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProcessOutputRequestWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProcessOutputRequest={ProcessOutputRequestEmpty()}>
</ProcessOutputRequestWindow>
)
};
export default ProcessOutputRequestWindow;