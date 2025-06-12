// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAnexamentoRegistros } from '../../Interfaces/interface.AnexamentoRegistros';
import { AnexamentoRegistrosService } from '../../Services/AnexamentoRegistros.service';
import { AnexamentoRegistrosApi } from '../../Apis/ApiAnexamentoRegistros';
import AnexamentoRegistrosWindow from './AnexamentoRegistrosWindow';
import {AnexamentoRegistrosEmpty } from '@/app/GerAdv_TS/Models/AnexamentoRegistros';
interface AnexamentoRegistrosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AnexamentoRegistrosWindowId: React.FC<AnexamentoRegistrosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const anexamentoregistrosService = useMemo(() => {
  return new AnexamentoRegistrosService(
  new AnexamentoRegistrosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAnexamentoRegistros | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AnexamentoRegistrosEmpty() as IAnexamentoRegistros);
      return;
    }
    if (id) {
      const response = await anexamentoregistrosService.fetchAnexamentoRegistrosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AnexamentoRegistrosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAnexamentoRegistros={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AnexamentoRegistrosWindowId;