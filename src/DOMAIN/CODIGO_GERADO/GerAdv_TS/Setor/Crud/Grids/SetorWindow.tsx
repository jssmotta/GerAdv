// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import SetorInc from '../Inc/Setor';
import { ISetor } from '../../Interfaces/interface.Setor';
import { useIsMobile } from '@/app/context/MobileContext';
import { SetorEmpty } from '@/app/GerAdv_TS/Models/Setor';
import { useWindow } from '@/app/hooks/useWindows';
interface SetorWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedSetor?: ISetor;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const SetorWindow: React.FC<SetorWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedSetor, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Setor'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedSetor?.id ?? 0).toString()}
>
<SetorInc
id={selectedSetor?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowSetor: React.FC<SetorWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<SetorWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedSetor={SetorEmpty()}>
</SetorWindow>
)
};
export default SetorWindow;