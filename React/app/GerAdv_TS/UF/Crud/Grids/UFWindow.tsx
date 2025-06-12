// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import UFInc from '../Inc/UF';
import { IUF } from '../../Interfaces/interface.UF';
import { useIsMobile } from '@/app/context/MobileContext';
import { UFEmpty } from '@/app/GerAdv_TS/Models/UF';
import { useWindow } from '@/app/hooks/useWindows';
interface UFWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedUF?: IUF;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const UFWindow: React.FC<UFWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedUF, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='UF'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedUF?.id ?? 0).toString()}
>
<UFInc
id={selectedUF?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowUF: React.FC<UFWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<UFWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedUF={UFEmpty()}>
</UFWindow>
)
};
export default UFWindow;