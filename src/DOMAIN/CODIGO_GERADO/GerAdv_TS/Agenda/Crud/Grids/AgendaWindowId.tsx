// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAgenda } from '../../Interfaces/interface.Agenda';
import { AgendaService } from '../../Services/Agenda.service';
import { AgendaApi } from '../../Apis/ApiAgenda';
import AgendaWindow from './AgendaWindow';
import {AgendaEmpty } from '@/app/GerAdv_TS/Models/Agenda';
interface AgendaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AgendaWindowId: React.FC<AgendaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const agendaService = useMemo(() => {
  return new AgendaService(
  new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAgenda | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AgendaEmpty() as IAgenda);
      return;
    }
    if (id) {
      const response = await agendaService.fetchAgendaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AgendaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAgenda={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AgendaWindowId;