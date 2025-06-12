// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IFornecedores } from '../../Interfaces/interface.Fornecedores';
import { FornecedoresService } from '../../Services/Fornecedores.service';
import { FornecedoresApi } from '../../Apis/ApiFornecedores';
import FornecedoresWindow from './FornecedoresWindow';
import {FornecedoresEmpty } from '@/app/GerAdv_TS/Models/Fornecedores';
interface FornecedoresWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const FornecedoresWindowId: React.FC<FornecedoresWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const fornecedoresService = useMemo(() => {
  return new FornecedoresService(
  new FornecedoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IFornecedores | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(FornecedoresEmpty() as IFornecedores);
      return;
    }
    if (id) {
      const response = await fornecedoresService.fetchFornecedoresById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <FornecedoresWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedFornecedores={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default FornecedoresWindowId;