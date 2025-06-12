// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ClientesInc from '../Inc/Clientes';
import { IClientes } from '../../Interfaces/interface.Clientes';
import { useIsMobile } from '@/app/context/MobileContext';
import { ClientesEmpty } from '@/app/GerAdv_TS/Models/Clientes';
import { useWindow } from '@/app/hooks/useWindows';
interface ClientesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedClientes?: IClientes;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ClientesWindow: React.FC<ClientesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedClientes, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Clientes'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={905}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedClientes?.id ?? 0).toString()}
>
<ClientesInc
id={selectedClientes?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowClientes: React.FC<ClientesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ClientesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedClientes={ClientesEmpty()}>
</ClientesWindow>
)
};
export default ClientesWindow;