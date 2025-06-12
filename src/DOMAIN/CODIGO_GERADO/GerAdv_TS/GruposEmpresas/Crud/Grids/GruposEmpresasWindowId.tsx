// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IGruposEmpresas } from '../../Interfaces/interface.GruposEmpresas';
import { GruposEmpresasService } from '../../Services/GruposEmpresas.service';
import { GruposEmpresasApi } from '../../Apis/ApiGruposEmpresas';
import GruposEmpresasWindow from './GruposEmpresasWindow';
import {GruposEmpresasEmpty } from '@/app/GerAdv_TS/Models/GruposEmpresas';
interface GruposEmpresasWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GruposEmpresasWindowId: React.FC<GruposEmpresasWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const gruposempresasService = useMemo(() => {
  return new GruposEmpresasService(
  new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IGruposEmpresas | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(GruposEmpresasEmpty() as IGruposEmpresas);
      return;
    }
    if (id) {
      const response = await gruposempresasService.fetchGruposEmpresasById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <GruposEmpresasWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedGruposEmpresas={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default GruposEmpresasWindowId;