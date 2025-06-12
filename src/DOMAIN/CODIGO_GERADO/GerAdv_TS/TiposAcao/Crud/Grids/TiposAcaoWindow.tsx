// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TiposAcaoInc from '../Inc/TiposAcao';
import { ITiposAcao } from '../../Interfaces/interface.TiposAcao';
import { useIsMobile } from '@/app/context/MobileContext';
import { TiposAcaoEmpty } from '@/app/GerAdv_TS/Models/TiposAcao';
import { useWindow } from '@/app/hooks/useWindows';
interface TiposAcaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTiposAcao?: ITiposAcao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TiposAcaoWindow: React.FC<TiposAcaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTiposAcao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Tipos Acao'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTiposAcao?.id ?? 0).toString()}
>
<TiposAcaoInc
id={selectedTiposAcao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTiposAcao: React.FC<TiposAcaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TiposAcaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTiposAcao={TiposAcaoEmpty()}>
</TiposAcaoWindow>
)
};
export default TiposAcaoWindow;