// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProcessOutPutIDsInc from '../Inc/ProcessOutPutIDs';
import { IProcessOutPutIDs } from '../../Interfaces/interface.ProcessOutPutIDs';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProcessOutPutIDsEmpty } from '@/app/GerAdv_TS/Models/ProcessOutPutIDs';
import { useWindow } from '@/app/hooks/useWindows';
interface ProcessOutPutIDsWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProcessOutPutIDs?: IProcessOutPutIDs;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProcessOutPutIDsWindow: React.FC<ProcessOutPutIDsWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProcessOutPutIDs, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Process Out Put I Ds'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProcessOutPutIDs?.id ?? 0).toString()}
>
<ProcessOutPutIDsInc
id={selectedProcessOutPutIDs?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProcessOutPutIDs: React.FC<ProcessOutPutIDsWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProcessOutPutIDsWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProcessOutPutIDs={ProcessOutPutIDsEmpty()}>
</ProcessOutPutIDsWindow>
)
};
export default ProcessOutPutIDsWindow;