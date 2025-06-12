// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import BensMateriaisInc from '../Inc/BensMateriais';
import { IBensMateriais } from '../../Interfaces/interface.BensMateriais';
import { useIsMobile } from '@/app/context/MobileContext';
import { BensMateriaisEmpty } from '@/app/GerAdv_TS/Models/BensMateriais';
import { useWindow } from '@/app/hooks/useWindows';
interface BensMateriaisWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedBensMateriais?: IBensMateriais;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const BensMateriaisWindow: React.FC<BensMateriaisWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedBensMateriais, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Bens Materiais'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={641}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedBensMateriais?.id ?? 0).toString()}
>
<BensMateriaisInc
id={selectedBensMateriais?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowBensMateriais: React.FC<BensMateriaisWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<BensMateriaisWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedBensMateriais={BensMateriaisEmpty()}>
</BensMateriaisWindow>
)
};
export default BensMateriaisWindow;