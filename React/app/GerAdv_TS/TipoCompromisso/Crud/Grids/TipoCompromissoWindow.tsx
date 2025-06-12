// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TipoCompromissoInc from '../Inc/TipoCompromisso';
import { ITipoCompromisso } from '../../Interfaces/interface.TipoCompromisso';
import { useIsMobile } from '@/app/context/MobileContext';
import { TipoCompromissoEmpty } from '@/app/GerAdv_TS/Models/TipoCompromisso';
import { useWindow } from '@/app/hooks/useWindows';
interface TipoCompromissoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTipoCompromisso?: ITipoCompromisso;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoCompromissoWindow: React.FC<TipoCompromissoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTipoCompromisso, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Tipo Compromisso'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTipoCompromisso?.id ?? 0).toString()}
>
<TipoCompromissoInc
id={selectedTipoCompromisso?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTipoCompromisso: React.FC<TipoCompromissoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TipoCompromissoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTipoCompromisso={TipoCompromissoEmpty()}>
</TipoCompromissoWindow>
)
};
export default TipoCompromissoWindow;