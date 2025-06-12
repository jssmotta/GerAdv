// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import PreClientesInc from '../Inc/PreClientes';
import { IPreClientes } from '../../Interfaces/interface.PreClientes';
import { useIsMobile } from '@/app/context/MobileContext';
import { PreClientesEmpty } from '@/app/GerAdv_TS/Models/PreClientes';
import { useWindow } from '@/app/hooks/useWindows';
interface PreClientesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedPreClientes?: IPreClientes;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const PreClientesWindow: React.FC<PreClientesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedPreClientes, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Pre Clientes'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={905}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedPreClientes?.id ?? 0).toString()}
>
<PreClientesInc
id={selectedPreClientes?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowPreClientes: React.FC<PreClientesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<PreClientesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedPreClientes={PreClientesEmpty()}>
</PreClientesWindow>
)
};
export default PreClientesWindow;