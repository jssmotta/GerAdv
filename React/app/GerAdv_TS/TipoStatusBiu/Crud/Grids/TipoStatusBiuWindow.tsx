// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TipoStatusBiuInc from '../Inc/TipoStatusBiu';
import { ITipoStatusBiu } from '../../Interfaces/interface.TipoStatusBiu';
import { useIsMobile } from '@/app/context/MobileContext';
import { TipoStatusBiuEmpty } from '@/app/GerAdv_TS/Models/TipoStatusBiu';
import { useWindow } from '@/app/hooks/useWindows';
interface TipoStatusBiuWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTipoStatusBiu?: ITipoStatusBiu;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoStatusBiuWindow: React.FC<TipoStatusBiuWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTipoStatusBiu, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Staus  Usuários'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTipoStatusBiu?.id ?? 0).toString()}
>
<TipoStatusBiuInc
id={selectedTipoStatusBiu?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTipoStatusBiu: React.FC<TipoStatusBiuWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TipoStatusBiuWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTipoStatusBiu={TipoStatusBiuEmpty()}>
</TipoStatusBiuWindow>
)
};
export default TipoStatusBiuWindow;