// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProPartes } from '../../Interfaces/interface.ProPartes';
import { ProPartesService } from '../../Services/ProPartes.service';
import { ProPartesApi } from '../../Apis/ApiProPartes';
import ProPartesWindow from './ProPartesWindow';
import {ProPartesEmpty } from '@/app/GerAdv_TS/Models/ProPartes';
interface ProPartesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProPartesWindowId: React.FC<ProPartesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const propartesService = useMemo(() => {
  return new ProPartesService(
  new ProPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProPartes | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProPartesEmpty() as IProPartes);
      return;
    }
    if (id) {
      const response = await propartesService.fetchProPartesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProPartesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProPartes={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProPartesWindowId;