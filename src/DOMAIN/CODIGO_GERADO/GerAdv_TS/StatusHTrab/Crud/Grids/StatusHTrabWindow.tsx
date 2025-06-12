// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import StatusHTrabInc from '../Inc/StatusHTrab';
import { IStatusHTrab } from '../../Interfaces/interface.StatusHTrab';
import { useIsMobile } from '@/app/context/MobileContext';
import { StatusHTrabEmpty } from '@/app/GerAdv_TS/Models/StatusHTrab';
import { useWindow } from '@/app/hooks/useWindows';
interface StatusHTrabWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedStatusHTrab?: IStatusHTrab;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const StatusHTrabWindow: React.FC<StatusHTrabWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedStatusHTrab, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Status H Trab'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedStatusHTrab?.id ?? 0).toString()}
>
<StatusHTrabInc
id={selectedStatusHTrab?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowStatusHTrab: React.FC<StatusHTrabWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<StatusHTrabWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedStatusHTrab={StatusHTrabEmpty()}>
</StatusHTrabWindow>
)
};
export default StatusHTrabWindow;