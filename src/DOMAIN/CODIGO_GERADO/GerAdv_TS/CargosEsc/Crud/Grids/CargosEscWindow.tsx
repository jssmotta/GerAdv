// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import CargosEscInc from '../Inc/CargosEsc';
import { ICargosEsc } from '../../Interfaces/interface.CargosEsc';
import { useIsMobile } from '@/app/context/MobileContext';
import { CargosEscEmpty } from '@/app/GerAdv_TS/Models/CargosEsc';
import { useWindow } from '@/app/hooks/useWindows';
interface CargosEscWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedCargosEsc?: ICargosEsc;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const CargosEscWindow: React.FC<CargosEscWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedCargosEsc, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Cargos Esc'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedCargosEsc?.id ?? 0).toString()}
>
<CargosEscInc
id={selectedCargosEsc?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowCargosEsc: React.FC<CargosEscWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<CargosEscWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedCargosEsc={CargosEscEmpty()}>
</CargosEscWindow>
)
};
export default CargosEscWindow;