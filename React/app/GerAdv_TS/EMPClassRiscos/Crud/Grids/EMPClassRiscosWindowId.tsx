// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IEMPClassRiscos } from '../../Interfaces/interface.EMPClassRiscos';
import { EMPClassRiscosService } from '../../Services/EMPClassRiscos.service';
import { EMPClassRiscosApi } from '../../Apis/ApiEMPClassRiscos';
import EMPClassRiscosWindow from './EMPClassRiscosWindow';
import {EMPClassRiscosEmpty } from '@/app/GerAdv_TS/Models/EMPClassRiscos';
interface EMPClassRiscosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const EMPClassRiscosWindowId: React.FC<EMPClassRiscosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const empclassriscosService = useMemo(() => {
  return new EMPClassRiscosService(
  new EMPClassRiscosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IEMPClassRiscos | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(EMPClassRiscosEmpty() as IEMPClassRiscos);
      return;
    }
    if (id) {
      const response = await empclassriscosService.fetchEMPClassRiscosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <EMPClassRiscosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedEMPClassRiscos={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default EMPClassRiscosWindowId;