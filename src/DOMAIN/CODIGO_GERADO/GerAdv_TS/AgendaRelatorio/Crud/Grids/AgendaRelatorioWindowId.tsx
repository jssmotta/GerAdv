// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAgendaRelatorio } from '../../Interfaces/interface.AgendaRelatorio';
import { AgendaRelatorioService } from '../../Services/AgendaRelatorio.service';
import { AgendaRelatorioApi } from '../../Apis/ApiAgendaRelatorio';
import AgendaRelatorioWindow from './AgendaRelatorioWindow';
import {AgendaRelatorioEmpty } from '@/app/GerAdv_TS/Models/AgendaRelatorio';
interface AgendaRelatorioWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AgendaRelatorioWindowId: React.FC<AgendaRelatorioWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const agendarelatorioService = useMemo(() => {
  return new AgendaRelatorioService(
  new AgendaRelatorioApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAgendaRelatorio | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AgendaRelatorioEmpty() as IAgendaRelatorio);
      return;
    }
    if (id) {
      const response = await agendarelatorioService.fetchAgendaRelatorioById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AgendaRelatorioWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAgendaRelatorio={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AgendaRelatorioWindowId;