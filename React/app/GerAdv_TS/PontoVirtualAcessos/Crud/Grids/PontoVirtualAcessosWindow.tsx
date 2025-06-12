// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import PontoVirtualAcessosInc from '../Inc/PontoVirtualAcessos';
import { IPontoVirtualAcessos } from '../../Interfaces/interface.PontoVirtualAcessos';
import { useIsMobile } from '@/app/context/MobileContext';
import { PontoVirtualAcessosEmpty } from '@/app/GerAdv_TS/Models/PontoVirtualAcessos';
import { useWindow } from '@/app/hooks/useWindows';
interface PontoVirtualAcessosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedPontoVirtualAcessos?: IPontoVirtualAcessos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const PontoVirtualAcessosWindow: React.FC<PontoVirtualAcessosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedPontoVirtualAcessos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Ponto Virtual Acessos'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedPontoVirtualAcessos?.id ?? 0).toString()}
>
<PontoVirtualAcessosInc
id={selectedPontoVirtualAcessos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowPontoVirtualAcessos: React.FC<PontoVirtualAcessosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<PontoVirtualAcessosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedPontoVirtualAcessos={PontoVirtualAcessosEmpty()}>
</PontoVirtualAcessosWindow>
)
};
export default PontoVirtualAcessosWindow;