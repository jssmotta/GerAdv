// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import EnderecosInc from '../Inc/Enderecos';
import { IEnderecos } from '../../Interfaces/interface.Enderecos';
import { useIsMobile } from '@/app/context/MobileContext';
import { EnderecosEmpty } from '@/app/GerAdv_TS/Models/Enderecos';
import { useWindow } from '@/app/hooks/useWindows';
interface EnderecosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedEnderecos?: IEnderecos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const EnderecosWindow: React.FC<EnderecosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedEnderecos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Endereço'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={732}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedEnderecos?.id ?? 0).toString()}
>
<EnderecosInc
id={selectedEnderecos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowEnderecos: React.FC<EnderecosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<EnderecosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedEnderecos={EnderecosEmpty()}>
</EnderecosWindow>
)
};
export default EnderecosWindow;