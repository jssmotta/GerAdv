// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAcao } from '../../Interfaces/interface.Acao';
import { AcaoService } from '../../Services/Acao.service';
import { AcaoApi } from '../../Apis/ApiAcao';
import AcaoWindow from './AcaoWindow';
import {AcaoEmpty } from '@/app/GerAdv_TS/Models/Acao';
interface AcaoWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AcaoWindowId: React.FC<AcaoWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const acaoService = useMemo(() => {
  return new AcaoService(
  new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAcao | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AcaoEmpty() as IAcao);
      return;
    }
    if (id) {
      const response = await acaoService.fetchAcaoById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AcaoWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAcao={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AcaoWindowId;