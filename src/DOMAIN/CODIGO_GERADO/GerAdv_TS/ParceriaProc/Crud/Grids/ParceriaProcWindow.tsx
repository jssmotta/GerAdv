// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ParceriaProcInc from '../Inc/ParceriaProc';
import { IParceriaProc } from '../../Interfaces/interface.ParceriaProc';
import { useIsMobile } from '@/app/context/MobileContext';
import { ParceriaProcEmpty } from '@/app/GerAdv_TS/Models/ParceriaProc';
import { useWindow } from '@/app/hooks/useWindows';
interface ParceriaProcWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedParceriaProc?: IParceriaProc;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ParceriaProcWindow: React.FC<ParceriaProcWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedParceriaProc, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Parceria Proc'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedParceriaProc?.id ?? 0).toString()}
>
<ParceriaProcInc
id={selectedParceriaProc?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowParceriaProc: React.FC<ParceriaProcWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ParceriaProcWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedParceriaProc={ParceriaProcEmpty()}>
</ParceriaProcWindow>
)
};
export default ParceriaProcWindow;