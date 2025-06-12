// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import GUTPeriodicidadeStatusInc from '../Inc/GUTPeriodicidadeStatus';
import { IGUTPeriodicidadeStatus } from '../../Interfaces/interface.GUTPeriodicidadeStatus';
import { useIsMobile } from '@/app/context/MobileContext';
import { GUTPeriodicidadeStatusEmpty } from '@/app/GerAdv_TS/Models/GUTPeriodicidadeStatus';
import { useWindow } from '@/app/hooks/useWindows';
interface GUTPeriodicidadeStatusWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedGUTPeriodicidadeStatus?: IGUTPeriodicidadeStatus;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GUTPeriodicidadeStatusWindow: React.FC<GUTPeriodicidadeStatusWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedGUTPeriodicidadeStatus, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='G U T Periodicidade Status'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedGUTPeriodicidadeStatus?.id ?? 0).toString()}
>
<GUTPeriodicidadeStatusInc
id={selectedGUTPeriodicidadeStatus?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowGUTPeriodicidadeStatus: React.FC<GUTPeriodicidadeStatusWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<GUTPeriodicidadeStatusWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedGUTPeriodicidadeStatus={GUTPeriodicidadeStatusEmpty()}>
</GUTPeriodicidadeStatusWindow>
)
};
export default GUTPeriodicidadeStatusWindow;