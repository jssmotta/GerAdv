// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAlertas } from '../../Interfaces/interface.Alertas';
import { AlertasService } from '../../Services/Alertas.service';
import { AlertasApi } from '../../Apis/ApiAlertas';
import AlertasWindow from './AlertasWindow';
import {AlertasEmpty } from '@/app/GerAdv_TS/Models/Alertas';
interface AlertasWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AlertasWindowId: React.FC<AlertasWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const alertasService = useMemo(() => {
  return new AlertasService(
  new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAlertas | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AlertasEmpty() as IAlertas);
      return;
    }
    if (id) {
      const response = await alertasService.fetchAlertasById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AlertasWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAlertas={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AlertasWindowId;