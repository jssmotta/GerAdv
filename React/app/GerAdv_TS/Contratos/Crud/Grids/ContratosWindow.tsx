// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ContratosInc from '../Inc/Contratos';
import { IContratos } from '../../Interfaces/interface.Contratos';
import { useIsMobile } from '@/app/context/MobileContext';
import { ContratosEmpty } from '@/app/GerAdv_TS/Models/Contratos';
import { useWindow } from '@/app/hooks/useWindows';
interface ContratosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedContratos?: IContratos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ContratosWindow: React.FC<ContratosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedContratos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Contratos'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={905}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedContratos?.id ?? 0).toString()}
>
<ContratosInc
id={selectedContratos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowContratos: React.FC<ContratosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ContratosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedContratos={ContratosEmpty()}>
</ContratosWindow>
)
};
export default ContratosWindow;