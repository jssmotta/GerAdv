// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import GUTAtividadesMatrizInc from '../Inc/GUTAtividadesMatriz';
import { IGUTAtividadesMatriz } from '../../Interfaces/interface.GUTAtividadesMatriz';
import { useIsMobile } from '@/app/context/MobileContext';
import { GUTAtividadesMatrizEmpty } from '@/app/GerAdv_TS/Models/GUTAtividadesMatriz';
import { useWindow } from '@/app/hooks/useWindows';
interface GUTAtividadesMatrizWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedGUTAtividadesMatriz?: IGUTAtividadesMatriz;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GUTAtividadesMatrizWindow: React.FC<GUTAtividadesMatrizWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedGUTAtividadesMatriz, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='G U T Atividades Matriz'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedGUTAtividadesMatriz?.id ?? 0).toString()}
>
<GUTAtividadesMatrizInc
id={selectedGUTAtividadesMatriz?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowGUTAtividadesMatriz: React.FC<GUTAtividadesMatrizWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<GUTAtividadesMatrizWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedGUTAtividadesMatriz={GUTAtividadesMatrizEmpty()}>
</GUTAtividadesMatrizWindow>
)
};
export default GUTAtividadesMatrizWindow;