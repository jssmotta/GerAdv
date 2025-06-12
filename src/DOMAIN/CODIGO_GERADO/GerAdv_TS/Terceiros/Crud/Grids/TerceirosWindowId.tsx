// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ITerceiros } from '../../Interfaces/interface.Terceiros';
import { TerceirosService } from '../../Services/Terceiros.service';
import { TerceirosApi } from '../../Apis/ApiTerceiros';
import TerceirosWindow from './TerceirosWindow';
import {TerceirosEmpty } from '@/app/GerAdv_TS/Models/Terceiros';
interface TerceirosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TerceirosWindowId: React.FC<TerceirosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const terceirosService = useMemo(() => {
  return new TerceirosService(
  new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ITerceiros | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(TerceirosEmpty() as ITerceiros);
      return;
    }
    if (id) {
      const response = await terceirosService.fetchTerceirosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <TerceirosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedTerceiros={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default TerceirosWindowId;