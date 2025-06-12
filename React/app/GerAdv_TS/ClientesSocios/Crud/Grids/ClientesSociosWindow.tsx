// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ClientesSociosInc from '../Inc/ClientesSocios';
import { IClientesSocios } from '../../Interfaces/interface.ClientesSocios';
import { useIsMobile } from '@/app/context/MobileContext';
import { ClientesSociosEmpty } from '@/app/GerAdv_TS/Models/ClientesSocios';
import { useWindow } from '@/app/hooks/useWindows';
interface ClientesSociosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedClientesSocios?: IClientesSocios;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ClientesSociosWindow: React.FC<ClientesSociosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedClientesSocios, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Clientes Socios'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={905}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedClientesSocios?.id ?? 0).toString()}
>
<ClientesSociosInc
id={selectedClientesSocios?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowClientesSocios: React.FC<ClientesSociosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ClientesSociosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedClientesSocios={ClientesSociosEmpty()}>
</ClientesSociosWindow>
)
};
export default ClientesSociosWindow;