// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import DivisaoTribunalInc from '../Inc/DivisaoTribunal';
import { IDivisaoTribunal } from '../../Interfaces/interface.DivisaoTribunal';
import { useIsMobile } from '@/app/context/MobileContext';
import { DivisaoTribunalEmpty } from '@/app/GerAdv_TS/Models/DivisaoTribunal';
import { useWindow } from '@/app/hooks/useWindows';
interface DivisaoTribunalWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedDivisaoTribunal?: IDivisaoTribunal;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const DivisaoTribunalWindow: React.FC<DivisaoTribunalWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedDivisaoTribunal, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Divisao Tribunal'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={702}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedDivisaoTribunal?.id ?? 0).toString()}
>
<DivisaoTribunalInc
id={selectedDivisaoTribunal?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowDivisaoTribunal: React.FC<DivisaoTribunalWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<DivisaoTribunalWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedDivisaoTribunal={DivisaoTribunalEmpty()}>
</DivisaoTribunalWindow>
)
};
export default DivisaoTribunalWindow;