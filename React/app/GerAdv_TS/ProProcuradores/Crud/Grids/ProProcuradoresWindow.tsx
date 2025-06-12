// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProProcuradoresInc from '../Inc/ProProcuradores';
import { IProProcuradores } from '../../Interfaces/interface.ProProcuradores';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProProcuradoresEmpty } from '@/app/GerAdv_TS/Models/ProProcuradores';
import { useWindow } from '@/app/hooks/useWindows';
interface ProProcuradoresWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProProcuradores?: IProProcuradores;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProProcuradoresWindow: React.FC<ProProcuradoresWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProProcuradores, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Pro Procuradores'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={633}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProProcuradores?.id ?? 0).toString()}
>
<ProProcuradoresInc
id={selectedProProcuradores?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProProcuradores: React.FC<ProProcuradoresWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProProcuradoresWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProProcuradores={ProProcuradoresEmpty()}>
</ProProcuradoresWindow>
)
};
export default ProProcuradoresWindow;