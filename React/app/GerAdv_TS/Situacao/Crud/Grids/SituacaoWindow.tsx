// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import SituacaoInc from '../Inc/Situacao';
import { ISituacao } from '../../Interfaces/interface.Situacao';
import { useIsMobile } from '@/app/context/MobileContext';
import { SituacaoEmpty } from '@/app/GerAdv_TS/Models/Situacao';
import { useWindow } from '@/app/hooks/useWindows';
interface SituacaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedSituacao?: ISituacao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const SituacaoWindow: React.FC<SituacaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedSituacao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Situação'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedSituacao?.id ?? 0).toString()}
>
<SituacaoInc
id={selectedSituacao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowSituacao: React.FC<SituacaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<SituacaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedSituacao={SituacaoEmpty()}>
</SituacaoWindow>
)
};
export default SituacaoWindow;