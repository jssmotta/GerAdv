// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAlertasEnviados } from '../../Interfaces/interface.AlertasEnviados';
import { AlertasEnviadosService } from '../../Services/AlertasEnviados.service';
import { AlertasEnviadosApi } from '../../Apis/ApiAlertasEnviados';
import AlertasEnviadosWindow from './AlertasEnviadosWindow';
import {AlertasEnviadosEmpty } from '@/app/GerAdv_TS/Models/AlertasEnviados';
interface AlertasEnviadosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AlertasEnviadosWindowId: React.FC<AlertasEnviadosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const alertasenviadosService = useMemo(() => {
  return new AlertasEnviadosService(
  new AlertasEnviadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAlertasEnviados | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AlertasEnviadosEmpty() as IAlertasEnviados);
      return;
    }
    if (id) {
      const response = await alertasenviadosService.fetchAlertasEnviadosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AlertasEnviadosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAlertasEnviados={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AlertasEnviadosWindowId;