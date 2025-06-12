// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IProTipoBaixa } from '../../Interfaces/interface.ProTipoBaixa';
import { ProTipoBaixaService } from '../../Services/ProTipoBaixa.service';
import { ProTipoBaixaApi } from '../../Apis/ApiProTipoBaixa';
import ProTipoBaixaWindow from './ProTipoBaixaWindow';
import {ProTipoBaixaEmpty } from '@/app/GerAdv_TS/Models/ProTipoBaixa';
interface ProTipoBaixaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProTipoBaixaWindowId: React.FC<ProTipoBaixaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const protipobaixaService = useMemo(() => {
  return new ProTipoBaixaService(
  new ProTipoBaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IProTipoBaixa | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ProTipoBaixaEmpty() as IProTipoBaixa);
      return;
    }
    if (id) {
      const response = await protipobaixaService.fetchProTipoBaixaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ProTipoBaixaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedProTipoBaixa={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ProTipoBaixaWindowId;