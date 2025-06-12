// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ILivroCaixaClientes } from '../../Interfaces/interface.LivroCaixaClientes';
import { LivroCaixaClientesService } from '../../Services/LivroCaixaClientes.service';
import { LivroCaixaClientesApi } from '../../Apis/ApiLivroCaixaClientes';
import LivroCaixaClientesWindow from './LivroCaixaClientesWindow';
import {LivroCaixaClientesEmpty } from '@/app/GerAdv_TS/Models/LivroCaixaClientes';
interface LivroCaixaClientesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const LivroCaixaClientesWindowId: React.FC<LivroCaixaClientesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const livrocaixaclientesService = useMemo(() => {
  return new LivroCaixaClientesService(
  new LivroCaixaClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ILivroCaixaClientes | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(LivroCaixaClientesEmpty() as ILivroCaixaClientes);
      return;
    }
    if (id) {
      const response = await livrocaixaclientesService.fetchLivroCaixaClientesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <LivroCaixaClientesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedLivroCaixaClientes={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default LivroCaixaClientesWindowId;