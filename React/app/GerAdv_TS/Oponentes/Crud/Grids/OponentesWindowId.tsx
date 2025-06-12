// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IOponentes } from '../../Interfaces/interface.Oponentes';
import { OponentesService } from '../../Services/Oponentes.service';
import { OponentesApi } from '../../Apis/ApiOponentes';
import OponentesWindow from './OponentesWindow';
import {OponentesEmpty } from '@/app/GerAdv_TS/Models/Oponentes';
interface OponentesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OponentesWindowId: React.FC<OponentesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const oponentesService = useMemo(() => {
  return new OponentesService(
  new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IOponentes | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(OponentesEmpty() as IOponentes);
      return;
    }
    if (id) {
      const response = await oponentesService.fetchOponentesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <OponentesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedOponentes={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default OponentesWindowId;