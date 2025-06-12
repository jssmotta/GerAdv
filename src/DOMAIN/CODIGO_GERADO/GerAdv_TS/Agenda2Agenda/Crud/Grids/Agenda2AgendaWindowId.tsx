// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAgenda2Agenda } from '../../Interfaces/interface.Agenda2Agenda';
import { Agenda2AgendaService } from '../../Services/Agenda2Agenda.service';
import { Agenda2AgendaApi } from '../../Apis/ApiAgenda2Agenda';
import Agenda2AgendaWindow from './Agenda2AgendaWindow';
import {Agenda2AgendaEmpty } from '@/app/GerAdv_TS/Models/Agenda2Agenda';
interface Agenda2AgendaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const Agenda2AgendaWindowId: React.FC<Agenda2AgendaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const agenda2agendaService = useMemo(() => {
  return new Agenda2AgendaService(
  new Agenda2AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAgenda2Agenda | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(Agenda2AgendaEmpty() as IAgenda2Agenda);
      return;
    }
    if (id) {
      const response = await agenda2agendaService.fetchAgenda2AgendaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <Agenda2AgendaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAgenda2Agenda={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default Agenda2AgendaWindowId;