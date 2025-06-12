// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IUltimosProcessos } from '../../Interfaces/interface.UltimosProcessos';
import { UltimosProcessosService } from '../../Services/UltimosProcessos.service';
import { UltimosProcessosApi } from '../../Apis/ApiUltimosProcessos';
import UltimosProcessosWindow from './UltimosProcessosWindow';
import {UltimosProcessosEmpty } from '@/app/GerAdv_TS/Models/UltimosProcessos';
interface UltimosProcessosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const UltimosProcessosWindowId: React.FC<UltimosProcessosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const ultimosprocessosService = useMemo(() => {
  return new UltimosProcessosService(
  new UltimosProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IUltimosProcessos | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(UltimosProcessosEmpty() as IUltimosProcessos);
      return;
    }
    if (id) {
      const response = await ultimosprocessosService.fetchUltimosProcessosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <UltimosProcessosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedUltimosProcessos={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default UltimosProcessosWindowId;