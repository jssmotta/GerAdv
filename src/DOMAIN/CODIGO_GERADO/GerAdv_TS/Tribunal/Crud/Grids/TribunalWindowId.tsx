// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ITribunal } from '../../Interfaces/interface.Tribunal';
import { TribunalService } from '../../Services/Tribunal.service';
import { TribunalApi } from '../../Apis/ApiTribunal';
import TribunalWindow from './TribunalWindow';
import {TribunalEmpty } from '@/app/GerAdv_TS/Models/Tribunal';
interface TribunalWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TribunalWindowId: React.FC<TribunalWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const tribunalService = useMemo(() => {
  return new TribunalService(
  new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ITribunal | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(TribunalEmpty() as ITribunal);
      return;
    }
    if (id) {
      const response = await tribunalService.fetchTribunalById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <TribunalWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedTribunal={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default TribunalWindowId;