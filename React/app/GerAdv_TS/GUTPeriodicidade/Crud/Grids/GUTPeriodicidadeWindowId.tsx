// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IGUTPeriodicidade } from '../../Interfaces/interface.GUTPeriodicidade';
import { GUTPeriodicidadeService } from '../../Services/GUTPeriodicidade.service';
import { GUTPeriodicidadeApi } from '../../Apis/ApiGUTPeriodicidade';
import GUTPeriodicidadeWindow from './GUTPeriodicidadeWindow';
import {GUTPeriodicidadeEmpty } from '@/app/GerAdv_TS/Models/GUTPeriodicidade';
interface GUTPeriodicidadeWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GUTPeriodicidadeWindowId: React.FC<GUTPeriodicidadeWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const gutperiodicidadeService = useMemo(() => {
  return new GUTPeriodicidadeService(
  new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IGUTPeriodicidade | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(GUTPeriodicidadeEmpty() as IGUTPeriodicidade);
      return;
    }
    if (id) {
      const response = await gutperiodicidadeService.fetchGUTPeriodicidadeById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <GUTPeriodicidadeWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedGUTPeriodicidade={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default GUTPeriodicidadeWindowId;