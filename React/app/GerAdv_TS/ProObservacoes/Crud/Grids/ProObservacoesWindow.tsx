// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProObservacoesInc from '../Inc/ProObservacoes';
import { IProObservacoes } from '../../Interfaces/interface.ProObservacoes';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProObservacoesEmpty } from '@/app/GerAdv_TS/Models/ProObservacoes';
import { useWindow } from '@/app/hooks/useWindows';
interface ProObservacoesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProObservacoes?: IProObservacoes;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProObservacoesWindow: React.FC<ProObservacoesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProObservacoes, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Pro Observacoes'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProObservacoes?.id ?? 0).toString()}
>
<ProObservacoesInc
id={selectedProObservacoes?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProObservacoes: React.FC<ProObservacoesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProObservacoesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProObservacoes={ProObservacoesEmpty()}>
</ProObservacoesWindow>
)
};
export default ProObservacoesWindow;