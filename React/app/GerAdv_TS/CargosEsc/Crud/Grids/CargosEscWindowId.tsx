// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ICargosEsc } from '../../Interfaces/interface.CargosEsc';
import { CargosEscService } from '../../Services/CargosEsc.service';
import { CargosEscApi } from '../../Apis/ApiCargosEsc';
import CargosEscWindow from './CargosEscWindow';
import {CargosEscEmpty } from '@/app/GerAdv_TS/Models/CargosEsc';
interface CargosEscWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const CargosEscWindowId: React.FC<CargosEscWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const cargosescService = useMemo(() => {
  return new CargosEscService(
  new CargosEscApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ICargosEsc | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(CargosEscEmpty() as ICargosEsc);
      return;
    }
    if (id) {
      const response = await cargosescService.fetchCargosEscById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <CargosEscWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedCargosEsc={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default CargosEscWindowId;