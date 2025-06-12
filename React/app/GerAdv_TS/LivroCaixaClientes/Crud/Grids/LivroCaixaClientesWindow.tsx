// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import LivroCaixaClientesInc from '../Inc/LivroCaixaClientes';
import { ILivroCaixaClientes } from '../../Interfaces/interface.LivroCaixaClientes';
import { useIsMobile } from '@/app/context/MobileContext';
import { LivroCaixaClientesEmpty } from '@/app/GerAdv_TS/Models/LivroCaixaClientes';
import { useWindow } from '@/app/hooks/useWindows';
interface LivroCaixaClientesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedLivroCaixaClientes?: ILivroCaixaClientes;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const LivroCaixaClientesWindow: React.FC<LivroCaixaClientesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedLivroCaixaClientes, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Livro Caixa Clientes'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedLivroCaixaClientes?.id ?? 0).toString()}
>
<LivroCaixaClientesInc
id={selectedLivroCaixaClientes?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowLivroCaixaClientes: React.FC<LivroCaixaClientesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<LivroCaixaClientesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedLivroCaixaClientes={LivroCaixaClientesEmpty()}>
</LivroCaixaClientesWindow>
)
};
export default LivroCaixaClientesWindow;