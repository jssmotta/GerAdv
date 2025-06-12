// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IRamal } from '../../Interfaces/interface.Ramal';
import { RamalService } from '../../Services/Ramal.service';
import { RamalApi } from '../../Apis/ApiRamal';
import RamalWindow from './RamalWindow';
import {RamalEmpty } from '@/app/GerAdv_TS/Models/Ramal';
interface RamalWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const RamalWindowId: React.FC<RamalWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const ramalService = useMemo(() => {
  return new RamalService(
  new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IRamal | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(RamalEmpty() as IRamal);
      return;
    }
    if (id) {
      const response = await ramalService.fetchRamalById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <RamalWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedRamal={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default RamalWindowId;