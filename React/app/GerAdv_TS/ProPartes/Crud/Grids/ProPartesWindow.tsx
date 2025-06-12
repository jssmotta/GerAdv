// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProPartesInc from '../Inc/ProPartes';
import { IProPartes } from '../../Interfaces/interface.ProPartes';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProPartesEmpty } from '@/app/GerAdv_TS/Models/ProPartes';
import { useWindow } from '@/app/hooks/useWindows';
interface ProPartesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProPartes?: IProPartes;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProPartesWindow: React.FC<ProPartesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProPartes, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Pro Partes'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProPartes?.id ?? 0).toString()}
>
<ProPartesInc
id={selectedProPartes?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProPartes: React.FC<ProPartesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProPartesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProPartes={ProPartesEmpty()}>
</ProPartesWindow>
)
};
export default ProPartesWindow;