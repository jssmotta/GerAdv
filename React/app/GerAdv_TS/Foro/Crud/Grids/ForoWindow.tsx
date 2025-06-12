// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ForoInc from '../Inc/Foro';
import { IForo } from '../../Interfaces/interface.Foro';
import { useIsMobile } from '@/app/context/MobileContext';
import { ForoEmpty } from '@/app/GerAdv_TS/Models/Foro';
import { useWindow } from '@/app/hooks/useWindows';
interface ForoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedForo?: IForo;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ForoWindow: React.FC<ForoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedForo, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Foro'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={602}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedForo?.id ?? 0).toString()}
>
<ForoInc
id={selectedForo?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowForo: React.FC<ForoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ForoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedForo={ForoEmpty()}>
</ForoWindow>
)
};
export default ForoWindow;