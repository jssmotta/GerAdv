// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import RamalInc from '../Inc/Ramal';
import { IRamal } from '../../Interfaces/interface.Ramal';
import { useIsMobile } from '@/app/context/MobileContext';
import { RamalEmpty } from '@/app/GerAdv_TS/Models/Ramal';
import { useWindow } from '@/app/hooks/useWindows';
interface RamalWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedRamal?: IRamal;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const RamalWindow: React.FC<RamalWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedRamal, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Ramal'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedRamal?.id ?? 0).toString()}
>
<RamalInc
id={selectedRamal?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowRamal: React.FC<RamalWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<RamalWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedRamal={RamalEmpty()}>
</RamalWindow>
)
};
export default RamalWindow;