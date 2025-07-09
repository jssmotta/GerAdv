// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ReuniaoInc from '../Inc/Reuniao';
import { IReuniao } from '../../Interfaces/interface.Reuniao';
import { useIsMobile } from '@/app/context/MobileContext';
import { ReuniaoEmpty } from '@/app/GerAdv_TS/Models/Reuniao';
import { useWindow } from '@/app/hooks/useWindows';
interface ReuniaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedReuniao?: IReuniao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ReuniaoWindow: React.FC<ReuniaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedReuniao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Reunião'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={596}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedReuniao?.id ?? 0).toString()}
>
<ReuniaoInc
id={selectedReuniao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowReuniao: React.FC<ReuniaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ReuniaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedReuniao={ReuniaoEmpty()}>
</ReuniaoWindow>
)
};
export default ReuniaoWindow;