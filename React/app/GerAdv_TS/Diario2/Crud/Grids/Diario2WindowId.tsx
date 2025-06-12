// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IDiario2 } from '../../Interfaces/interface.Diario2';
import { Diario2Service } from '../../Services/Diario2.service';
import { Diario2Api } from '../../Apis/ApiDiario2';
import Diario2Window from './Diario2Window';
import {Diario2Empty } from '@/app/GerAdv_TS/Models/Diario2';
interface Diario2WindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const Diario2WindowId: React.FC<Diario2WindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const diario2Service = useMemo(() => {
  return new Diario2Service(
  new Diario2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IDiario2 | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(Diario2Empty() as IDiario2);
      return;
    }
    if (id) {
      const response = await diario2Service.fetchDiario2ById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <Diario2Window
  isOpen={isOpen}
  onClose={onClose}
  selectedDiario2={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default Diario2WindowId;