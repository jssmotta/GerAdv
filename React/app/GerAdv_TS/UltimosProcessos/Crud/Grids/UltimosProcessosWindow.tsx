// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import UltimosProcessosInc from '../Inc/UltimosProcessos';
import { IUltimosProcessos } from '../../Interfaces/interface.UltimosProcessos';
import { useIsMobile } from '@/app/context/MobileContext';
import { UltimosProcessosEmpty } from '@/app/GerAdv_TS/Models/UltimosProcessos';
import { useWindow } from '@/app/hooks/useWindows';
interface UltimosProcessosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedUltimosProcessos?: IUltimosProcessos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const UltimosProcessosWindow: React.FC<UltimosProcessosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedUltimosProcessos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Ultimos Processos'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedUltimosProcessos?.id ?? 0).toString()}
>
<UltimosProcessosInc
id={selectedUltimosProcessos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowUltimosProcessos: React.FC<UltimosProcessosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<UltimosProcessosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedUltimosProcessos={UltimosProcessosEmpty()}>
</UltimosProcessosWindow>
)
};
export default UltimosProcessosWindow;