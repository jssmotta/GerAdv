// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProTipoBaixaInc from '../Inc/ProTipoBaixa';
import { IProTipoBaixa } from '../../Interfaces/interface.ProTipoBaixa';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProTipoBaixaEmpty } from '@/app/GerAdv_TS/Models/ProTipoBaixa';
import { useWindow } from '@/app/hooks/useWindows';
interface ProTipoBaixaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProTipoBaixa?: IProTipoBaixa;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProTipoBaixaWindow: React.FC<ProTipoBaixaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProTipoBaixa, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Pro Tipo Baixa'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProTipoBaixa?.id ?? 0).toString()}
>
<ProTipoBaixaInc
id={selectedProTipoBaixa?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProTipoBaixa: React.FC<ProTipoBaixaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProTipoBaixaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProTipoBaixa={ProTipoBaixaEmpty()}>
</ProTipoBaixaWindow>
)
};
export default ProTipoBaixaWindow;