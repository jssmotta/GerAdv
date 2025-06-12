// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IPenhoraStatus } from '../../Interfaces/interface.PenhoraStatus';
import { PenhoraStatusService } from '../../Services/PenhoraStatus.service';
import { PenhoraStatusApi } from '../../Apis/ApiPenhoraStatus';
import PenhoraStatusWindow from './PenhoraStatusWindow';
import {PenhoraStatusEmpty } from '@/app/GerAdv_TS/Models/PenhoraStatus';
interface PenhoraStatusWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const PenhoraStatusWindowId: React.FC<PenhoraStatusWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const penhorastatusService = useMemo(() => {
  return new PenhoraStatusService(
  new PenhoraStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IPenhoraStatus | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(PenhoraStatusEmpty() as IPenhoraStatus);
      return;
    }
    if (id) {
      const response = await penhorastatusService.fetchPenhoraStatusById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <PenhoraStatusWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedPenhoraStatus={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default PenhoraStatusWindowId;