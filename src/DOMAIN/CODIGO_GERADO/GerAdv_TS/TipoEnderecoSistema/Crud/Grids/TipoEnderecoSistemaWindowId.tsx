// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ITipoEnderecoSistema } from '../../Interfaces/interface.TipoEnderecoSistema';
import { TipoEnderecoSistemaService } from '../../Services/TipoEnderecoSistema.service';
import { TipoEnderecoSistemaApi } from '../../Apis/ApiTipoEnderecoSistema';
import TipoEnderecoSistemaWindow from './TipoEnderecoSistemaWindow';
import {TipoEnderecoSistemaEmpty } from '@/app/GerAdv_TS/Models/TipoEnderecoSistema';
interface TipoEnderecoSistemaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const TipoEnderecoSistemaWindowId: React.FC<TipoEnderecoSistemaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const tipoenderecosistemaService = useMemo(() => {
  return new TipoEnderecoSistemaService(
  new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ITipoEnderecoSistema | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(TipoEnderecoSistemaEmpty() as ITipoEnderecoSistema);
      return;
    }
    if (id) {
      const response = await tipoenderecosistemaService.fetchTipoEnderecoSistemaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <TipoEnderecoSistemaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedTipoEnderecoSistema={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default TipoEnderecoSistemaWindowId;