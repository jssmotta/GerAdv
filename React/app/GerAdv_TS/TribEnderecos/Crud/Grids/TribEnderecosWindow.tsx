// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TribEnderecosInc from '../Inc/TribEnderecos';
import { ITribEnderecos } from '../../Interfaces/interface.TribEnderecos';
import { useIsMobile } from '@/app/context/MobileContext';
import { TribEnderecosEmpty } from '@/app/GerAdv_TS/Models/TribEnderecos';
import { useWindow } from '@/app/hooks/useWindows';
interface TribEnderecosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTribEnderecos?: ITribEnderecos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TribEnderecosWindow: React.FC<TribEnderecosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTribEnderecos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Trib Endereços'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={725}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTribEnderecos?.id ?? 0).toString()}
>
<TribEnderecosInc
id={selectedTribEnderecos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTribEnderecos: React.FC<TribEnderecosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TribEnderecosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTribEnderecos={TribEnderecosEmpty()}>
</TribEnderecosWindow>
)
};
export default TribEnderecosWindow;