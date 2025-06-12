// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IJustica } from '../../Interfaces/interface.Justica';
import { JusticaService } from '../../Services/Justica.service';
import { JusticaApi } from '../../Apis/ApiJustica';
import JusticaWindow from './JusticaWindow';
import {JusticaEmpty } from '@/app/GerAdv_TS/Models/Justica';
interface JusticaWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const JusticaWindowId: React.FC<JusticaWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const justicaService = useMemo(() => {
  return new JusticaService(
  new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IJustica | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(JusticaEmpty() as IJustica);
      return;
    }
    if (id) {
      const response = await justicaService.fetchJusticaById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <JusticaWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedJustica={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default JusticaWindowId;