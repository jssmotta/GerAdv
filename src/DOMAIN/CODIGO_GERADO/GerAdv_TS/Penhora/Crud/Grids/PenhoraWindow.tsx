// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import PenhoraInc from '../Inc/Penhora';
import { IPenhora } from '../../Interfaces/interface.Penhora';
import { useIsMobile } from '@/app/context/MobileContext';
import { PenhoraEmpty } from '@/app/GerAdv_TS/Models/Penhora';
import { useWindow } from '@/app/hooks/useWindows';
interface PenhoraWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedPenhora?: IPenhora;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const PenhoraWindow: React.FC<PenhoraWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedPenhora, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Penhora'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={633}
  newWidth={900}
  mobile={isMobile}
  id={(selectedPenhora?.id ?? 0).toString()}
>
<PenhoraInc
id={selectedPenhora?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowPenhora: React.FC<PenhoraWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<PenhoraWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedPenhora={PenhoraEmpty()}>
</PenhoraWindow>
)
};
export default PenhoraWindow;