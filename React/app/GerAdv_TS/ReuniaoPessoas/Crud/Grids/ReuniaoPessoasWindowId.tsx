// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IReuniaoPessoas } from '../../Interfaces/interface.ReuniaoPessoas';
import { ReuniaoPessoasService } from '../../Services/ReuniaoPessoas.service';
import { ReuniaoPessoasApi } from '../../Apis/ApiReuniaoPessoas';
import ReuniaoPessoasWindow from './ReuniaoPessoasWindow';
import {ReuniaoPessoasEmpty } from '@/app/GerAdv_TS/Models/ReuniaoPessoas';
interface ReuniaoPessoasWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ReuniaoPessoasWindowId: React.FC<ReuniaoPessoasWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const reuniaopessoasService = useMemo(() => {
  return new ReuniaoPessoasService(
  new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IReuniaoPessoas | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ReuniaoPessoasEmpty() as IReuniaoPessoas);
      return;
    }
    if (id) {
      const response = await reuniaopessoasService.fetchReuniaoPessoasById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ReuniaoPessoasWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedReuniaoPessoas={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ReuniaoPessoasWindowId;