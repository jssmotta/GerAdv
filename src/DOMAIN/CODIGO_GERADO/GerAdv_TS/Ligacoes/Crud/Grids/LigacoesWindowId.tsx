// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ILigacoes } from '../../Interfaces/interface.Ligacoes';
import { LigacoesService } from '../../Services/Ligacoes.service';
import { LigacoesApi } from '../../Apis/ApiLigacoes';
import LigacoesWindow from './LigacoesWindow';
import {LigacoesEmpty } from '@/app/GerAdv_TS/Models/Ligacoes';
interface LigacoesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const LigacoesWindowId: React.FC<LigacoesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const ligacoesService = useMemo(() => {
  return new LigacoesService(
  new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ILigacoes | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(LigacoesEmpty() as ILigacoes);
      return;
    }
    if (id) {
      const response = await ligacoesService.fetchLigacoesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <LigacoesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedLigacoes={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default LigacoesWindowId;