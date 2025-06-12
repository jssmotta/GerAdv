// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProcessOutputEngine } from '../../Interfaces/interface.ProcessOutputEngine';
import { ProcessOutputEngineService } from '../../Services/ProcessOutputEngine.service';
import { ProcessOutputEngineApi } from '../../Apis/ApiProcessOutputEngine';
import ProcessOutputEngineWindow from './ProcessOutputEngineWindow';
import {ProcessOutputEngineEmpty } from '@/app/GerAdv_TS/Models/ProcessOutputEngine';
interface ProcessOutputEngineWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProcessOutputEngineWindowId: React.FC<ProcessOutputEngineWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const processoutputengineService = useMemo(() => {
  return new ProcessOutputEngineService(
  new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProcessOutputEngine | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProcessOutputEngineEmpty() as IProcessOutputEngine);
      return;
    }
    if (id) {
      const response = await processoutputengineService.fetchProcessOutputEngineById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProcessOutputEngineWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProcessOutputEngine={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProcessOutputEngineWindowId;