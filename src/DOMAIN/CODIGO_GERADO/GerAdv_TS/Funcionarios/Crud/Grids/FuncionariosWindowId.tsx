// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IFuncionarios } from '../../Interfaces/interface.Funcionarios';
import { FuncionariosService } from '../../Services/Funcionarios.service';
import { FuncionariosApi } from '../../Apis/ApiFuncionarios';
import FuncionariosWindow from './FuncionariosWindow';
import {FuncionariosEmpty } from '@/app/GerAdv_TS/Models/Funcionarios';
interface FuncionariosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const FuncionariosWindowId: React.FC<FuncionariosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const funcionariosService = useMemo(() => {
  return new FuncionariosService(
  new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IFuncionarios | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(FuncionariosEmpty() as IFuncionarios);
      return;
    }
    if (id) {
      const response = await funcionariosService.fetchFuncionariosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <FuncionariosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedFuncionarios={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default FuncionariosWindowId;