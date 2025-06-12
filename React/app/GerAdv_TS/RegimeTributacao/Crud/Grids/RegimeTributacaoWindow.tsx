// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import RegimeTributacaoInc from '../Inc/RegimeTributacao';
import { IRegimeTributacao } from '../../Interfaces/interface.RegimeTributacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { RegimeTributacaoEmpty } from '@/app/GerAdv_TS/Models/RegimeTributacao';
import { useWindow } from '@/app/hooks/useWindows';
interface RegimeTributacaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedRegimeTributacao?: IRegimeTributacao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const RegimeTributacaoWindow: React.FC<RegimeTributacaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedRegimeTributacao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Regime Tributacao'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedRegimeTributacao?.id ?? 0).toString()}
>
<RegimeTributacaoInc
id={selectedRegimeTributacao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowRegimeTributacao: React.FC<RegimeTributacaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<RegimeTributacaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedRegimeTributacao={RegimeTributacaoEmpty()}>
</RegimeTributacaoWindow>
)
};
export default RegimeTributacaoWindow;