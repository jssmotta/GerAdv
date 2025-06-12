// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AreasJusticaInc from '../Inc/AreasJustica';
import { IAreasJustica } from '../../Interfaces/interface.AreasJustica';
import { useIsMobile } from '@/app/context/MobileContext';
import { AreasJusticaEmpty } from '@/app/GerAdv_TS/Models/AreasJustica';
import { useWindow } from '@/app/hooks/useWindows';
interface AreasJusticaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAreasJustica?: IAreasJustica;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AreasJusticaWindow: React.FC<AreasJusticaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAreasJustica, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Areas Justica'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedAreasJustica?.id ?? 0).toString()}
>
<AreasJusticaInc
id={selectedAreasJustica?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAreasJustica: React.FC<AreasJusticaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AreasJusticaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAreasJustica={AreasJusticaEmpty()}>
</AreasJusticaWindow>
)
};
export default AreasJusticaWindow;