// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ServicosInc from '../Inc/Servicos';
import { IServicos } from '../../Interfaces/interface.Servicos';
import { useIsMobile } from '@/app/context/MobileContext';
import { ServicosEmpty } from '@/app/GerAdv_TS/Models/Servicos';
import { useWindow } from '@/app/hooks/useWindows';
interface ServicosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedServicos?: IServicos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ServicosWindow: React.FC<ServicosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedServicos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Serviço'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedServicos?.id ?? 0).toString()}
>
<ServicosInc
id={selectedServicos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowServicos: React.FC<ServicosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ServicosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedServicos={ServicosEmpty()}>
</ServicosWindow>
)
};
export default ServicosWindow;