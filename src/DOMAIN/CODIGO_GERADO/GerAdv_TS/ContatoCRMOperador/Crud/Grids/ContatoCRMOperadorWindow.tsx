// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ContatoCRMOperadorInc from '../Inc/ContatoCRMOperador';
import { IContatoCRMOperador } from '../../Interfaces/interface.ContatoCRMOperador';
import { useIsMobile } from '@/app/context/MobileContext';
import { ContatoCRMOperadorEmpty } from '@/app/GerAdv_TS/Models/ContatoCRMOperador';
import { useWindow } from '@/app/hooks/useWindows';
interface ContatoCRMOperadorWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedContatoCRMOperador?: IContatoCRMOperador;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ContatoCRMOperadorWindow: React.FC<ContatoCRMOperadorWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedContatoCRMOperador, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Contato C R M Operador'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedContatoCRMOperador?.id ?? 0).toString()}
>
<ContatoCRMOperadorInc
id={selectedContatoCRMOperador?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowContatoCRMOperador: React.FC<ContatoCRMOperadorWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ContatoCRMOperadorWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedContatoCRMOperador={ContatoCRMOperadorEmpty()}>
</ContatoCRMOperadorWindow>
)
};
export default ContatoCRMOperadorWindow;