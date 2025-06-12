// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProcessos } from '../../Interfaces/interface.Processos';
import { ProcessosService } from '../../Services/Processos.service';
import { ProcessosApi } from '../../Apis/ApiProcessos';
import ProcessosWindow from './ProcessosWindow';
import {ProcessosEmpty } from '@/app/GerAdv_TS/Models/Processos';
interface ProcessosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProcessosWindowId: React.FC<ProcessosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const processosService = useMemo(() => {
  return new ProcessosService(
  new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProcessos | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProcessosEmpty() as IProcessos);
      return;
    }
    if (id) {
      const response = await processosService.fetchProcessosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProcessosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProcessos={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProcessosWindowId;