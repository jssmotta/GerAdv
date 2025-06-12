// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ICargosEscClass } from '../../Interfaces/interface.CargosEscClass';
import { CargosEscClassService } from '../../Services/CargosEscClass.service';
import { CargosEscClassApi } from '../../Apis/ApiCargosEscClass';
import CargosEscClassWindow from './CargosEscClassWindow';
import {CargosEscClassEmpty } from '@/app/GerAdv_TS/Models/CargosEscClass';
interface CargosEscClassWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const CargosEscClassWindowId: React.FC<CargosEscClassWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const cargosescclassService = useMemo(() => {
  return new CargosEscClassService(
  new CargosEscClassApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ICargosEscClass | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(CargosEscClassEmpty() as ICargosEscClass);
      return;
    }
    if (id) {
      const response = await cargosescclassService.fetchCargosEscClassById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <CargosEscClassWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedCargosEscClass={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default CargosEscClassWindowId;