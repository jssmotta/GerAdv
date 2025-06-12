// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TerceirosInc from '../Inc/Terceiros';
import { ITerceiros } from '../../Interfaces/interface.Terceiros';
import { useIsMobile } from '@/app/context/MobileContext';
import { TerceirosEmpty } from '@/app/GerAdv_TS/Models/Terceiros';
import { useWindow } from '@/app/hooks/useWindows';
interface TerceirosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTerceiros?: ITerceiros;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TerceirosWindow: React.FC<TerceirosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTerceiros, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Terceiros'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={641}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedTerceiros?.id ?? 0).toString()}
>
<TerceirosInc
id={selectedTerceiros?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTerceiros: React.FC<TerceirosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TerceirosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTerceiros={TerceirosEmpty()}>
</TerceirosWindow>
)
};
export default TerceirosWindow;