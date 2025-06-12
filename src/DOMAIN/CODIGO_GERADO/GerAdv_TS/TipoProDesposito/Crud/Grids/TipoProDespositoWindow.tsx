// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TipoProDespositoInc from '../Inc/TipoProDesposito';
import { ITipoProDesposito } from '../../Interfaces/interface.TipoProDesposito';
import { useIsMobile } from '@/app/context/MobileContext';
import { TipoProDespositoEmpty } from '@/app/GerAdv_TS/Models/TipoProDesposito';
import { useWindow } from '@/app/hooks/useWindows';
interface TipoProDespositoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTipoProDesposito?: ITipoProDesposito;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoProDespositoWindow: React.FC<TipoProDespositoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTipoProDesposito, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Tipo Pro Desposito'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTipoProDesposito?.id ?? 0).toString()}
>
<TipoProDespositoInc
id={selectedTipoProDesposito?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTipoProDesposito: React.FC<TipoProDespositoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TipoProDespositoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTipoProDesposito={TipoProDespositoEmpty()}>
</TipoProDespositoWindow>
)
};
export default TipoProDespositoWindow;