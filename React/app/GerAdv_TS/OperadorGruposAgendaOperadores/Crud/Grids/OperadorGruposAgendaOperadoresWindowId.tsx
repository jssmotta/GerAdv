// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IOperadorGruposAgendaOperadores } from '../../Interfaces/interface.OperadorGruposAgendaOperadores';
import { OperadorGruposAgendaOperadoresService } from '../../Services/OperadorGruposAgendaOperadores.service';
import { OperadorGruposAgendaOperadoresApi } from '../../Apis/ApiOperadorGruposAgendaOperadores';
import OperadorGruposAgendaOperadoresWindow from './OperadorGruposAgendaOperadoresWindow';
import {OperadorGruposAgendaOperadoresEmpty } from '@/app/GerAdv_TS/Models/OperadorGruposAgendaOperadores';
interface OperadorGruposAgendaOperadoresWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OperadorGruposAgendaOperadoresWindowId: React.FC<OperadorGruposAgendaOperadoresWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const operadorgruposagendaoperadoresService = useMemo(() => {
  return new OperadorGruposAgendaOperadoresService(
  new OperadorGruposAgendaOperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IOperadorGruposAgendaOperadores | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(OperadorGruposAgendaOperadoresEmpty() as IOperadorGruposAgendaOperadores);
      return;
    }
    if (id) {
      const response = await operadorgruposagendaoperadoresService.fetchOperadorGruposAgendaOperadoresById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <OperadorGruposAgendaOperadoresWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedOperadorGruposAgendaOperadores={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default OperadorGruposAgendaOperadoresWindowId;