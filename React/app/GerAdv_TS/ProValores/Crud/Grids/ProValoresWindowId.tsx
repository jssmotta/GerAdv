// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProValores } from '../../Interfaces/interface.ProValores';
import { ProValoresService } from '../../Services/ProValores.service';
import { ProValoresApi } from '../../Apis/ApiProValores';
import ProValoresWindow from './ProValoresWindow';
import {ProValoresEmpty } from '@/app/GerAdv_TS/Models/ProValores';
interface ProValoresWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProValoresWindowId: React.FC<ProValoresWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const provaloresService = useMemo(() => {
  return new ProValoresService(
  new ProValoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProValores | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProValoresEmpty() as IProValores);
      return;
    }
    if (id) {
      const response = await provaloresService.fetchProValoresById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProValoresWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProValores={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProValoresWindowId;