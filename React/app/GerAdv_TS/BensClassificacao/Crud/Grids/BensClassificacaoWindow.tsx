// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import BensClassificacaoInc from '../Inc/BensClassificacao';
import { IBensClassificacao } from '../../Interfaces/interface.BensClassificacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { BensClassificacaoEmpty } from '@/app/GerAdv_TS/Models/BensClassificacao';
import { useWindow } from '@/app/hooks/useWindows';
interface BensClassificacaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedBensClassificacao?: IBensClassificacao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const BensClassificacaoWindow: React.FC<BensClassificacaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedBensClassificacao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Bens Classificacao'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedBensClassificacao?.id ?? 0).toString()}
>
<BensClassificacaoInc
id={selectedBensClassificacao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowBensClassificacao: React.FC<BensClassificacaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<BensClassificacaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedBensClassificacao={BensClassificacaoEmpty()}>
</BensClassificacaoWindow>
)
};
export default BensClassificacaoWindow;