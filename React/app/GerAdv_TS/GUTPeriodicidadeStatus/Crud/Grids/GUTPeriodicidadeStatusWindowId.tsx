// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IGUTPeriodicidadeStatus } from '../../Interfaces/interface.GUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusService } from '../../Services/GUTPeriodicidadeStatus.service';
import { GUTPeriodicidadeStatusApi } from '../../Apis/ApiGUTPeriodicidadeStatus';
import GUTPeriodicidadeStatusWindow from './GUTPeriodicidadeStatusWindow';
import {GUTPeriodicidadeStatusEmpty } from '@/app/GerAdv_TS/Models/GUTPeriodicidadeStatus';
interface GUTPeriodicidadeStatusWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GUTPeriodicidadeStatusWindowId: React.FC<GUTPeriodicidadeStatusWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const gutperiodicidadestatusService = useMemo(() => {
  return new GUTPeriodicidadeStatusService(
  new GUTPeriodicidadeStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IGUTPeriodicidadeStatus | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(GUTPeriodicidadeStatusEmpty() as IGUTPeriodicidadeStatus);
      return;
    }
    if (id) {
      const response = await gutperiodicidadestatusService.fetchGUTPeriodicidadeStatusById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <GUTPeriodicidadeStatusWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedGUTPeriodicidadeStatus={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default GUTPeriodicidadeStatusWindowId;