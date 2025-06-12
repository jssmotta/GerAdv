// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IInstancia } from '../../Interfaces/interface.Instancia';
import { InstanciaService } from '../../Services/Instancia.service';
import { InstanciaApi } from '../../Apis/ApiInstancia';
import InstanciaWindow from './InstanciaWindow';
import {InstanciaEmpty } from '@/app/GerAdv_TS/Models/Instancia';
interface InstanciaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const InstanciaWindowId: React.FC<InstanciaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const instanciaService = useMemo(() => {
  return new InstanciaService(
  new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IInstancia | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(InstanciaEmpty() as IInstancia);
      return;
    }
    if (id) {
      const response = await instanciaService.fetchInstanciaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <InstanciaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedInstancia={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default InstanciaWindowId;