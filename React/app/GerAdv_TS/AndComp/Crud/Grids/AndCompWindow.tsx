// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AndCompInc from '../Inc/AndComp';
import { IAndComp } from '../../Interfaces/interface.AndComp';
import { useIsMobile } from '@/app/context/MobileContext';
import { AndCompEmpty } from '@/app/GerAdv_TS/Models/AndComp';
import { useWindow } from '@/app/hooks/useWindows';
interface AndCompWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAndComp?: IAndComp;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AndCompWindow: React.FC<AndCompWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAndComp, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='And Comp'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedAndComp?.id ?? 0).toString()}
>
<AndCompInc
id={selectedAndComp?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAndComp: React.FC<AndCompWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AndCompWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAndComp={AndCompEmpty()}>
</AndCompWindow>
)
};
export default AndCompWindow;