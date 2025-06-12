// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IFuncao } from '../../Interfaces/interface.Funcao';
import { FuncaoService } from '../../Services/Funcao.service';
import { FuncaoApi } from '../../Apis/ApiFuncao';
import FuncaoWindow from './FuncaoWindow';
import {FuncaoEmpty } from '@/app/GerAdv_TS/Models/Funcao';
interface FuncaoWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const FuncaoWindowId: React.FC<FuncaoWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const funcaoService = useMemo(() => {
  return new FuncaoService(
  new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IFuncao | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(FuncaoEmpty() as IFuncao);
      return;
    }
    if (id) {
      const response = await funcaoService.fetchFuncaoById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <FuncaoWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedFuncao={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default FuncaoWindowId;