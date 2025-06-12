// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import PaisesInc from '../Inc/Paises';
import { IPaises } from '../../Interfaces/interface.Paises';
import { useIsMobile } from '@/app/context/MobileContext';
import { PaisesEmpty } from '@/app/GerAdv_TS/Models/Paises';
import { useWindow } from '@/app/hooks/useWindows';
interface PaisesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedPaises?: IPaises;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const PaisesWindow: React.FC<PaisesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedPaises, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Paises'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedPaises?.id ?? 0).toString()}
>
<PaisesInc
id={selectedPaises?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowPaises: React.FC<PaisesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<PaisesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedPaises={PaisesEmpty()}>
</PaisesWindow>
)
};
export default PaisesWindow;