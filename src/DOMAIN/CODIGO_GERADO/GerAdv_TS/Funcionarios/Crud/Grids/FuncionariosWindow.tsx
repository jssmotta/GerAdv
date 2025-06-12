// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import FuncionariosInc from '../Inc/Funcionarios';
import { IFuncionarios } from '../../Interfaces/interface.Funcionarios';
import { useIsMobile } from '@/app/context/MobileContext';
import { FuncionariosEmpty } from '@/app/GerAdv_TS/Models/Funcionarios';
import { useWindow } from '@/app/hooks/useWindows';
interface FuncionariosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedFuncionarios?: IFuncionarios;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const FuncionariosWindow: React.FC<FuncionariosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedFuncionarios, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Colaborador'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={600}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedFuncionarios?.id ?? 0).toString()}
>
<FuncionariosInc
id={selectedFuncionarios?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowFuncionarios: React.FC<FuncionariosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<FuncionariosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedFuncionarios={FuncionariosEmpty()}>
</FuncionariosWindow>
)
};
export default FuncionariosWindow;