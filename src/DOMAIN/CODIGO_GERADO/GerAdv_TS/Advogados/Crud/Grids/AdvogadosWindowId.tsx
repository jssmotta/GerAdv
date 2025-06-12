// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAdvogados } from '../../Interfaces/interface.Advogados';
import { AdvogadosService } from '../../Services/Advogados.service';
import { AdvogadosApi } from '../../Apis/ApiAdvogados';
import AdvogadosWindow from './AdvogadosWindow';
import {AdvogadosEmpty } from '@/app/GerAdv_TS/Models/Advogados';
interface AdvogadosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AdvogadosWindowId: React.FC<AdvogadosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const advogadosService = useMemo(() => {
  return new AdvogadosService(
  new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAdvogados | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AdvogadosEmpty() as IAdvogados);
      return;
    }
    if (id) {
      const response = await advogadosService.fetchAdvogadosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AdvogadosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAdvogados={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AdvogadosWindowId;