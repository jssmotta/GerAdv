// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ContatoCRMInc from '../Inc/ContatoCRM';
import { IContatoCRM } from '../../Interfaces/interface.ContatoCRM';
import { useIsMobile } from '@/app/context/MobileContext';
import { ContatoCRMEmpty } from '@/app/GerAdv_TS/Models/ContatoCRM';
import { useWindow } from '@/app/hooks/useWindows';
interface ContatoCRMWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedContatoCRM?: IContatoCRM;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ContatoCRMWindow: React.FC<ContatoCRMWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedContatoCRM, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Contato C R M'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={824}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedContatoCRM?.id ?? 0).toString()}
>
<ContatoCRMInc
id={selectedContatoCRM?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowContatoCRM: React.FC<ContatoCRMWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ContatoCRMWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedContatoCRM={ContatoCRMEmpty()}>
</ContatoCRMWindow>
)
};
export default ContatoCRMWindow;