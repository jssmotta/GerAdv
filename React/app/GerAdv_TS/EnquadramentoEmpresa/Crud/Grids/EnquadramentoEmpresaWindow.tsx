// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import EnquadramentoEmpresaInc from '../Inc/EnquadramentoEmpresa';
import { IEnquadramentoEmpresa } from '../../Interfaces/interface.EnquadramentoEmpresa';
import { useIsMobile } from '@/app/context/MobileContext';
import { EnquadramentoEmpresaEmpty } from '@/app/GerAdv_TS/Models/EnquadramentoEmpresa';
import { useWindow } from '@/app/hooks/useWindows';
interface EnquadramentoEmpresaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedEnquadramentoEmpresa?: IEnquadramentoEmpresa;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const EnquadramentoEmpresaWindow: React.FC<EnquadramentoEmpresaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedEnquadramentoEmpresa, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Enquadramento Empresa'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedEnquadramentoEmpresa?.id ?? 0).toString()}
>
<EnquadramentoEmpresaInc
id={selectedEnquadramentoEmpresa?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowEnquadramentoEmpresa: React.FC<EnquadramentoEmpresaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<EnquadramentoEmpresaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedEnquadramentoEmpresa={EnquadramentoEmpresaEmpty()}>
</EnquadramentoEmpresaWindow>
)
};
export default EnquadramentoEmpresaWindow;