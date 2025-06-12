// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import HonorariosDadosContratoInc from '../Inc/HonorariosDadosContrato';
import { IHonorariosDadosContrato } from '../../Interfaces/interface.HonorariosDadosContrato';
import { useIsMobile } from '@/app/context/MobileContext';
import { HonorariosDadosContratoEmpty } from '@/app/GerAdv_TS/Models/HonorariosDadosContrato';
import { useWindow } from '@/app/hooks/useWindows';
interface HonorariosDadosContratoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedHonorariosDadosContrato?: IHonorariosDadosContrato;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const HonorariosDadosContratoWindow: React.FC<HonorariosDadosContratoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedHonorariosDadosContrato, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Honorarios Dados Contrato'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedHonorariosDadosContrato?.id ?? 0).toString()}
>
<HonorariosDadosContratoInc
id={selectedHonorariosDadosContrato?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowHonorariosDadosContrato: React.FC<HonorariosDadosContratoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<HonorariosDadosContratoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedHonorariosDadosContrato={HonorariosDadosContratoEmpty()}>
</HonorariosDadosContratoWindow>
)
};
export default HonorariosDadosContratoWindow;