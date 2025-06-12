// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TipoValorProcessoInc from '../Inc/TipoValorProcesso';
import { ITipoValorProcesso } from '../../Interfaces/interface.TipoValorProcesso';
import { useIsMobile } from '@/app/context/MobileContext';
import { TipoValorProcessoEmpty } from '@/app/GerAdv_TS/Models/TipoValorProcesso';
import { useWindow } from '@/app/hooks/useWindows';
interface TipoValorProcessoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTipoValorProcesso?: ITipoValorProcesso;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoValorProcessoWindow: React.FC<TipoValorProcessoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTipoValorProcesso, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Tipo Valor Processo'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTipoValorProcesso?.id ?? 0).toString()}
>
<TipoValorProcessoInc
id={selectedTipoValorProcesso?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTipoValorProcesso: React.FC<TipoValorProcessoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TipoValorProcessoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTipoValorProcesso={TipoValorProcessoEmpty()}>
</TipoValorProcessoWindow>
)
};
export default TipoValorProcessoWindow;