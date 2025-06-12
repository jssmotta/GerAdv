// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAgendaQuem } from '../../Interfaces/interface.AgendaQuem';
import { AgendaQuemService } from '../../Services/AgendaQuem.service';
import { AgendaQuemApi } from '../../Apis/ApiAgendaQuem';
import AgendaQuemWindow from './AgendaQuemWindow';
import {AgendaQuemEmpty } from '@/app/GerAdv_TS/Models/AgendaQuem';
interface AgendaQuemWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AgendaQuemWindowId: React.FC<AgendaQuemWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const agendaquemService = useMemo(() => {
  return new AgendaQuemService(
  new AgendaQuemApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAgendaQuem | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AgendaQuemEmpty() as IAgendaQuem);
      return;
    }
    if (id) {
      const response = await agendaquemService.fetchAgendaQuemById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AgendaQuemWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAgendaQuem={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AgendaQuemWindowId;