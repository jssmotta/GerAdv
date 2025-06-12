// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import PontoVirtualInc from '../Inc/PontoVirtual';
import { IPontoVirtual } from '../../Interfaces/interface.PontoVirtual';
import { useIsMobile } from '@/app/context/MobileContext';
import { PontoVirtualEmpty } from '@/app/GerAdv_TS/Models/PontoVirtual';
import { useWindow } from '@/app/hooks/useWindows';
interface PontoVirtualWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedPontoVirtual?: IPontoVirtual;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const PontoVirtualWindow: React.FC<PontoVirtualWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedPontoVirtual, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Ponto Virtual'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedPontoVirtual?.id ?? 0).toString()}
>
<PontoVirtualInc
id={selectedPontoVirtual?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowPontoVirtual: React.FC<PontoVirtualWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<PontoVirtualWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedPontoVirtual={PontoVirtualEmpty()}>
</PontoVirtualWindow>
)
};
export default PontoVirtualWindow;