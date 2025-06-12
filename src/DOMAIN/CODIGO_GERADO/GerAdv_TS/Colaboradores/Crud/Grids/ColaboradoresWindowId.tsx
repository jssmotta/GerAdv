// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IColaboradores } from '../../Interfaces/interface.Colaboradores';
import { ColaboradoresService } from '../../Services/Colaboradores.service';
import { ColaboradoresApi } from '../../Apis/ApiColaboradores';
import ColaboradoresWindow from './ColaboradoresWindow';
import {ColaboradoresEmpty } from '@/app/GerAdv_TS/Models/Colaboradores';
interface ColaboradoresWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ColaboradoresWindowId: React.FC<ColaboradoresWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const colaboradoresService = useMemo(() => {
  return new ColaboradoresService(
  new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IColaboradores | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ColaboradoresEmpty() as IColaboradores);
      return;
    }
    if (id) {
      const response = await colaboradoresService.fetchColaboradoresById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ColaboradoresWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedColaboradores={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ColaboradoresWindowId;