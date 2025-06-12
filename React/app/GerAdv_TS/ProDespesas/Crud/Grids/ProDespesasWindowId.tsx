// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProDespesas } from '../../Interfaces/interface.ProDespesas';
import { ProDespesasService } from '../../Services/ProDespesas.service';
import { ProDespesasApi } from '../../Apis/ApiProDespesas';
import ProDespesasWindow from './ProDespesasWindow';
import {ProDespesasEmpty } from '@/app/GerAdv_TS/Models/ProDespesas';
interface ProDespesasWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProDespesasWindowId: React.FC<ProDespesasWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const prodespesasService = useMemo(() => {
  return new ProDespesasService(
  new ProDespesasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProDespesas | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProDespesasEmpty() as IProDespesas);
      return;
    }
    if (id) {
      const response = await prodespesasService.fetchProDespesasById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProDespesasWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProDespesas={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProDespesasWindowId;