// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IEndTit } from '../../Interfaces/interface.EndTit';
import { EndTitService } from '../../Services/EndTit.service';
import { EndTitApi } from '../../Apis/ApiEndTit';
import EndTitWindow from './EndTitWindow';
import {EndTitEmpty } from '@/app/GerAdv_TS/Models/EndTit';
interface EndTitWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const EndTitWindowId: React.FC<EndTitWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const endtitService = useMemo(() => {
  return new EndTitService(
  new EndTitApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IEndTit | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(EndTitEmpty() as IEndTit);
      return;
    }
    if (id) {
      const response = await endtitService.fetchEndTitById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <EndTitWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedEndTit={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default EndTitWindowId;