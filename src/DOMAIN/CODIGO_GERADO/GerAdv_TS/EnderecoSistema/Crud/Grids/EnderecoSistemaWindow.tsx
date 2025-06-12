// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import EnderecoSistemaInc from '../Inc/EnderecoSistema';
import { IEnderecoSistema } from '../../Interfaces/interface.EnderecoSistema';
import { useIsMobile } from '@/app/context/MobileContext';
import { EnderecoSistemaEmpty } from '@/app/GerAdv_TS/Models/EnderecoSistema';
import { useWindow } from '@/app/hooks/useWindows';
interface EnderecoSistemaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedEnderecoSistema?: IEnderecoSistema;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const EnderecoSistemaWindow: React.FC<EnderecoSistemaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedEnderecoSistema, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Endereco Sistema'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={657}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedEnderecoSistema?.id ?? 0).toString()}
>
<EnderecoSistemaInc
id={selectedEnderecoSistema?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowEnderecoSistema: React.FC<EnderecoSistemaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<EnderecoSistemaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedEnderecoSistema={EnderecoSistemaEmpty()}>
</EnderecoSistemaWindow>
)
};
export default EnderecoSistemaWindow;