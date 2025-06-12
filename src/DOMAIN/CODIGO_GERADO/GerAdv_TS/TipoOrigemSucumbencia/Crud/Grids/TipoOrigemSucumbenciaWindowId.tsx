// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ITipoOrigemSucumbencia } from '../../Interfaces/interface.TipoOrigemSucumbencia';
import { TipoOrigemSucumbenciaService } from '../../Services/TipoOrigemSucumbencia.service';
import { TipoOrigemSucumbenciaApi } from '../../Apis/ApiTipoOrigemSucumbencia';
import TipoOrigemSucumbenciaWindow from './TipoOrigemSucumbenciaWindow';
import {TipoOrigemSucumbenciaEmpty } from '@/app/GerAdv_TS/Models/TipoOrigemSucumbencia';
interface TipoOrigemSucumbenciaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoOrigemSucumbenciaWindowId: React.FC<TipoOrigemSucumbenciaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const tipoorigemsucumbenciaService = useMemo(() => {
  return new TipoOrigemSucumbenciaService(
  new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ITipoOrigemSucumbencia | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(TipoOrigemSucumbenciaEmpty() as ITipoOrigemSucumbencia);
      return;
    }
    if (id) {
      const response = await tipoorigemsucumbenciaService.fetchTipoOrigemSucumbenciaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <TipoOrigemSucumbenciaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedTipoOrigemSucumbencia={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default TipoOrigemSucumbenciaWindowId;