// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { INEPalavrasChaves } from '../../Interfaces/interface.NEPalavrasChaves';
import { NEPalavrasChavesService } from '../../Services/NEPalavrasChaves.service';
import { NEPalavrasChavesApi } from '../../Apis/ApiNEPalavrasChaves';
import NEPalavrasChavesWindow from './NEPalavrasChavesWindow';
import {NEPalavrasChavesEmpty } from '@/app/GerAdv_TS/Models/NEPalavrasChaves';
interface NEPalavrasChavesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const NEPalavrasChavesWindowId: React.FC<NEPalavrasChavesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const nepalavraschavesService = useMemo(() => {
  return new NEPalavrasChavesService(
  new NEPalavrasChavesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<INEPalavrasChaves | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(NEPalavrasChavesEmpty() as INEPalavrasChaves);
      return;
    }
    if (id) {
      const response = await nepalavraschavesService.fetchNEPalavrasChavesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <NEPalavrasChavesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedNEPalavrasChaves={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default NEPalavrasChavesWindowId;