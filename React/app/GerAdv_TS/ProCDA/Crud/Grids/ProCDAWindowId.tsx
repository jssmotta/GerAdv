// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProCDA } from '../../Interfaces/interface.ProCDA';
import { ProCDAService } from '../../Services/ProCDA.service';
import { ProCDAApi } from '../../Apis/ApiProCDA';
import ProCDAWindow from './ProCDAWindow';
import {ProCDAEmpty } from '@/app/GerAdv_TS/Models/ProCDA';
interface ProCDAWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProCDAWindowId: React.FC<ProCDAWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const procdaService = useMemo(() => {
  return new ProCDAService(
  new ProCDAApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProCDA | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProCDAEmpty() as IProCDA);
      return;
    }
    if (id) {
      const response = await procdaService.fetchProCDAById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProCDAWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProCDA={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProCDAWindowId;