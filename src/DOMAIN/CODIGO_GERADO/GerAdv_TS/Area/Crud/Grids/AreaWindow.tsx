// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AreaInc from '../Inc/Area';
import { IArea } from '../../Interfaces/interface.Area';
import { useIsMobile } from '@/app/context/MobileContext';
import { AreaEmpty } from '@/app/GerAdv_TS/Models/Area';
import { useWindow } from '@/app/hooks/useWindows';
interface AreaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedArea?: IArea;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AreaWindow: React.FC<AreaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedArea, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Area'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedArea?.id ?? 0).toString()}
>
<AreaInc
id={selectedArea?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowArea: React.FC<AreaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AreaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedArea={AreaEmpty()}>
</AreaWindow>
)
};
export default AreaWindow;