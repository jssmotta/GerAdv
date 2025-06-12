// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import OponentesRepLegalInc from '../Inc/OponentesRepLegal';
import { IOponentesRepLegal } from '../../Interfaces/interface.OponentesRepLegal';
import { useIsMobile } from '@/app/context/MobileContext';
import { OponentesRepLegalEmpty } from '@/app/GerAdv_TS/Models/OponentesRepLegal';
import { useWindow } from '@/app/hooks/useWindows';
interface OponentesRepLegalWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedOponentesRepLegal?: IOponentesRepLegal;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OponentesRepLegalWindow: React.FC<OponentesRepLegalWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedOponentesRepLegal, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Oponentes Rep Legal'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={641}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedOponentesRepLegal?.id ?? 0).toString()}
>
<OponentesRepLegalInc
id={selectedOponentesRepLegal?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowOponentesRepLegal: React.FC<OponentesRepLegalWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<OponentesRepLegalWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedOponentesRepLegal={OponentesRepLegalEmpty()}>
</OponentesRepLegalWindow>
)
};
export default OponentesRepLegalWindow;