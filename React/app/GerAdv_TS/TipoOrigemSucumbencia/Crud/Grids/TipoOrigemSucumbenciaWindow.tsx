// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import TipoOrigemSucumbenciaInc from '../Inc/TipoOrigemSucumbencia';
import { ITipoOrigemSucumbencia } from '../../Interfaces/interface.TipoOrigemSucumbencia';
import { useIsMobile } from '@/app/context/MobileContext';
import { TipoOrigemSucumbenciaEmpty } from '@/app/GerAdv_TS/Models/TipoOrigemSucumbencia';
import { useWindow } from '@/app/hooks/useWindows';
interface TipoOrigemSucumbenciaWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedTipoOrigemSucumbencia?: ITipoOrigemSucumbencia;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoOrigemSucumbenciaWindow: React.FC<TipoOrigemSucumbenciaWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedTipoOrigemSucumbencia, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Tipo Origem Sucumbencia'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedTipoOrigemSucumbencia?.id ?? 0).toString()}
>
<TipoOrigemSucumbenciaInc
id={selectedTipoOrigemSucumbencia?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowTipoOrigemSucumbencia: React.FC<TipoOrigemSucumbenciaWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<TipoOrigemSucumbenciaWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedTipoOrigemSucumbencia={TipoOrigemSucumbenciaEmpty()}>
</TipoOrigemSucumbenciaWindow>
)
};
export default TipoOrigemSucumbenciaWindow;