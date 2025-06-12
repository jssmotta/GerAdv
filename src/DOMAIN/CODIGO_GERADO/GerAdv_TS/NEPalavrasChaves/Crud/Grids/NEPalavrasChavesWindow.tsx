// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import NEPalavrasChavesInc from '../Inc/NEPalavrasChaves';
import { INEPalavrasChaves } from '../../Interfaces/interface.NEPalavrasChaves';
import { useIsMobile } from '@/app/context/MobileContext';
import { NEPalavrasChavesEmpty } from '@/app/GerAdv_TS/Models/NEPalavrasChaves';
import { useWindow } from '@/app/hooks/useWindows';
interface NEPalavrasChavesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedNEPalavrasChaves?: INEPalavrasChaves;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const NEPalavrasChavesWindow: React.FC<NEPalavrasChavesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedNEPalavrasChaves, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='N E Palavras Chaves'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedNEPalavrasChaves?.id ?? 0).toString()}
>
<NEPalavrasChavesInc
id={selectedNEPalavrasChaves?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowNEPalavrasChaves: React.FC<NEPalavrasChavesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<NEPalavrasChavesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedNEPalavrasChaves={NEPalavrasChavesEmpty()}>
</NEPalavrasChavesWindow>
)
};
export default NEPalavrasChavesWindow;