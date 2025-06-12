// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IRegimeTributacao } from '../../Interfaces/interface.RegimeTributacao';
import { RegimeTributacaoService } from '../../Services/RegimeTributacao.service';
import { RegimeTributacaoApi } from '../../Apis/ApiRegimeTributacao';
import RegimeTributacaoWindow from './RegimeTributacaoWindow';
import {RegimeTributacaoEmpty } from '@/app/GerAdv_TS/Models/RegimeTributacao';
interface RegimeTributacaoWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const RegimeTributacaoWindowId: React.FC<RegimeTributacaoWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const regimetributacaoService = useMemo(() => {
  return new RegimeTributacaoService(
  new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IRegimeTributacao | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(RegimeTributacaoEmpty() as IRegimeTributacao);
      return;
    }
    if (id) {
      const response = await regimetributacaoService.fetchRegimeTributacaoById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <RegimeTributacaoWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedRegimeTributacao={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default RegimeTributacaoWindowId;