// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import Auditor4KInc from '../Inc/Auditor4K';
import { IAuditor4K } from '../../Interfaces/interface.Auditor4K';
import { useIsMobile } from '@/app/context/MobileContext';
import { Auditor4KEmpty } from '@/app/GerAdv_TS/Models/Auditor4K';
import { useWindow } from '@/app/hooks/useWindows';
interface Auditor4KWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAuditor4K?: IAuditor4K;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const Auditor4KWindow: React.FC<Auditor4KWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAuditor4K, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Auditor4 K'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedAuditor4K?.id ?? 0).toString()}
>
<Auditor4KInc
id={selectedAuditor4K?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAuditor4K: React.FC<Auditor4KWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<Auditor4KWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAuditor4K={Auditor4KEmpty()}>
</Auditor4KWindow>
)
};
export default Auditor4KWindow;