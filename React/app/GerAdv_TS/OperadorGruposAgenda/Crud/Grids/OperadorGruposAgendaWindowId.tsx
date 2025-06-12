// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IOperadorGruposAgenda } from '../../Interfaces/interface.OperadorGruposAgenda';
import { OperadorGruposAgendaService } from '../../Services/OperadorGruposAgenda.service';
import { OperadorGruposAgendaApi } from '../../Apis/ApiOperadorGruposAgenda';
import OperadorGruposAgendaWindow from './OperadorGruposAgendaWindow';
import {OperadorGruposAgendaEmpty } from '@/app/GerAdv_TS/Models/OperadorGruposAgenda';
interface OperadorGruposAgendaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OperadorGruposAgendaWindowId: React.FC<OperadorGruposAgendaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const operadorgruposagendaService = useMemo(() => {
  return new OperadorGruposAgendaService(
  new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IOperadorGruposAgenda | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(OperadorGruposAgendaEmpty() as IOperadorGruposAgenda);
      return;
    }
    if (id) {
      const response = await operadorgruposagendaService.fetchOperadorGruposAgendaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <OperadorGruposAgendaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedOperadorGruposAgenda={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default OperadorGruposAgendaWindowId;