// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAtividades } from '../../Interfaces/interface.Atividades';
import { AtividadesService } from '../../Services/Atividades.service';
import { AtividadesApi } from '../../Apis/ApiAtividades';
import AtividadesWindow from './AtividadesWindow';
import {AtividadesEmpty } from '@/app/GerAdv_TS/Models/Atividades';
interface AtividadesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AtividadesWindowId: React.FC<AtividadesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const atividadesService = useMemo(() => {
  return new AtividadesService(
  new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAtividades | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AtividadesEmpty() as IAtividades);
      return;
    }
    if (id) {
      const response = await atividadesService.fetchAtividadesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AtividadesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAtividades={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AtividadesWindowId;