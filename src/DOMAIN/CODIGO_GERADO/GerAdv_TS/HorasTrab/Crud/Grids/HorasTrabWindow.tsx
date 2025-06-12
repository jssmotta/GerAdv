// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import HorasTrabInc from '../Inc/HorasTrab';
import { IHorasTrab } from '../../Interfaces/interface.HorasTrab';
import { useIsMobile } from '@/app/context/MobileContext';
import { HorasTrabEmpty } from '@/app/GerAdv_TS/Models/HorasTrab';
import { useWindow } from '@/app/hooks/useWindows';
interface HorasTrabWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedHorasTrab?: IHorasTrab;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const HorasTrabWindow: React.FC<HorasTrabWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedHorasTrab, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Horas Trab'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={753}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedHorasTrab?.id ?? 0).toString()}
>
<HorasTrabInc
id={selectedHorasTrab?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowHorasTrab: React.FC<HorasTrabWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<HorasTrabWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedHorasTrab={HorasTrabEmpty()}>
</HorasTrabWindow>
)
};
export default HorasTrabWindow;