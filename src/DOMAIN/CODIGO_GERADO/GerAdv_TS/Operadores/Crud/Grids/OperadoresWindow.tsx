// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import OperadoresInc from '../Inc/Operadores';
import { IOperadores } from '../../Interfaces/interface.Operadores';
import { useIsMobile } from '@/app/context/MobileContext';
import { OperadoresEmpty } from '@/app/GerAdv_TS/Models/Operadores';
import { useWindow } from '@/app/hooks/useWindows';
interface OperadoresWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedOperadores?: IOperadores;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OperadoresWindow: React.FC<OperadoresWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedOperadores, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Operador'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedOperadores?.id ?? 0).toString()}
>
<OperadoresInc
id={selectedOperadores?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowOperadores: React.FC<OperadoresWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<OperadoresWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedOperadores={OperadoresEmpty()}>
</OperadoresWindow>
)
};
export default OperadoresWindow;