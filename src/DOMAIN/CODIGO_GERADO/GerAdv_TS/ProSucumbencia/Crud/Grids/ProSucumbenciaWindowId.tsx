// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProSucumbencia } from '../../Interfaces/interface.ProSucumbencia';
import { ProSucumbenciaService } from '../../Services/ProSucumbencia.service';
import { ProSucumbenciaApi } from '../../Apis/ApiProSucumbencia';
import ProSucumbenciaWindow from './ProSucumbenciaWindow';
import {ProSucumbenciaEmpty } from '@/app/GerAdv_TS/Models/ProSucumbencia';
interface ProSucumbenciaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProSucumbenciaWindowId: React.FC<ProSucumbenciaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const prosucumbenciaService = useMemo(() => {
  return new ProSucumbenciaService(
  new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProSucumbencia | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProSucumbenciaEmpty() as IProSucumbencia);
      return;
    }
    if (id) {
      const response = await prosucumbenciaService.fetchProSucumbenciaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProSucumbenciaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProSucumbencia={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProSucumbenciaWindowId;