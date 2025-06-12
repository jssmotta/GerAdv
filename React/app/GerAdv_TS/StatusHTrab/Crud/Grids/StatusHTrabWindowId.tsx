// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IStatusHTrab } from '../../Interfaces/interface.StatusHTrab';
import { StatusHTrabService } from '../../Services/StatusHTrab.service';
import { StatusHTrabApi } from '../../Apis/ApiStatusHTrab';
import StatusHTrabWindow from './StatusHTrabWindow';
import {StatusHTrabEmpty } from '@/app/GerAdv_TS/Models/StatusHTrab';
interface StatusHTrabWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const StatusHTrabWindowId: React.FC<StatusHTrabWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const statushtrabService = useMemo(() => {
  return new StatusHTrabService(
  new StatusHTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IStatusHTrab | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(StatusHTrabEmpty() as IStatusHTrab);
      return;
    }
    if (id) {
      const response = await statushtrabService.fetchStatusHTrabById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <StatusHTrabWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedStatusHTrab={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default StatusHTrabWindowId;