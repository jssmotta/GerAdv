// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IHistorico } from '../../Interfaces/interface.Historico';
import { HistoricoService } from '../../Services/Historico.service';
import { HistoricoApi } from '../../Apis/ApiHistorico';
import HistoricoWindow from './HistoricoWindow';
import {HistoricoEmpty } from '@/app/GerAdv_TS/Models/Historico';
interface HistoricoWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const HistoricoWindowId: React.FC<HistoricoWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const historicoService = useMemo(() => {
  return new HistoricoService(
  new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IHistorico | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(HistoricoEmpty() as IHistorico);
      return;
    }
    if (id) {
      const response = await historicoService.fetchHistoricoById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <HistoricoWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedHistorico={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default HistoricoWindowId;