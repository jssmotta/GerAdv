// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IStatusBiu } from '../../Interfaces/interface.StatusBiu';
import { StatusBiuService } from '../../Services/StatusBiu.service';
import { StatusBiuApi } from '../../Apis/ApiStatusBiu';
import StatusBiuWindow from './StatusBiuWindow';
import {StatusBiuEmpty } from '@/app/GerAdv_TS/Models/StatusBiu';
interface StatusBiuWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const StatusBiuWindowId: React.FC<StatusBiuWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const statusbiuService = useMemo(() => {
  return new StatusBiuService(
  new StatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IStatusBiu | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(StatusBiuEmpty() as IStatusBiu);
      return;
    }
    if (id) {
      const response = await statusbiuService.fetchStatusBiuById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <StatusBiuWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedStatusBiu={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default StatusBiuWindowId;