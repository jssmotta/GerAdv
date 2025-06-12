// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AlertasEnviadosInc from '../Inc/AlertasEnviados';
import { IAlertasEnviados } from '../../Interfaces/interface.AlertasEnviados';
import { useIsMobile } from '@/app/context/MobileContext';
import { AlertasEnviadosEmpty } from '@/app/GerAdv_TS/Models/AlertasEnviados';
import { useWindow } from '@/app/hooks/useWindows';
interface AlertasEnviadosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedAlertasEnviados?: IAlertasEnviados;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AlertasEnviadosWindow: React.FC<AlertasEnviadosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedAlertasEnviados, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Alertas Enviados'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedAlertasEnviados?.id ?? 0).toString()}
>
<AlertasEnviadosInc
id={selectedAlertasEnviados?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowAlertasEnviados: React.FC<AlertasEnviadosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<AlertasEnviadosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedAlertasEnviados={AlertasEnviadosEmpty()}>
</AlertasEnviadosWindow>
)
};
export default AlertasEnviadosWindow;