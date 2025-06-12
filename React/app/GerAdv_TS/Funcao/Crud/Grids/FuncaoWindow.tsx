// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import FuncaoInc from '../Inc/Funcao';
import { IFuncao } from '../../Interfaces/interface.Funcao';
import { useIsMobile } from '@/app/context/MobileContext';
import { FuncaoEmpty } from '@/app/GerAdv_TS/Models/Funcao';
import { useWindow } from '@/app/hooks/useWindows';
interface FuncaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedFuncao?: IFuncao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const FuncaoWindow: React.FC<FuncaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedFuncao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Função'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedFuncao?.id ?? 0).toString()}
>
<FuncaoInc
id={selectedFuncao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowFuncao: React.FC<FuncaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<FuncaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedFuncao={FuncaoEmpty()}>
</FuncaoWindow>
)
};
export default FuncaoWindow;