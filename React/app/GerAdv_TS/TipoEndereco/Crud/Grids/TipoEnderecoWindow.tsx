// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TipoEnderecoInc from '../Inc/TipoEndereco';
import { ITipoEndereco } from '../../Interfaces/interface.TipoEndereco';
import { useIsMobile } from '@/app/context/MobileContext';
import { TipoEnderecoEmpty } from '@/app/GerAdv_TS/Models/TipoEndereco';
import { useWindow } from '@/app/hooks/useWindows';
interface TipoEnderecoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTipoEndereco?: ITipoEndereco;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoEnderecoWindow: React.FC<TipoEnderecoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTipoEndereco, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Tipo Endereco'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTipoEndereco?.id ?? 0).toString()}
>
<TipoEnderecoInc
id={selectedTipoEndereco?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTipoEndereco: React.FC<TipoEnderecoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TipoEnderecoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTipoEndereco={TipoEnderecoEmpty()}>
</TipoEnderecoWindow>
)
};
export default TipoEnderecoWindow;