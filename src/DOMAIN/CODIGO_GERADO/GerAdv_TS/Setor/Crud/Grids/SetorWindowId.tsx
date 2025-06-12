// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { ISetor } from '../../Interfaces/interface.Setor';
import { SetorService } from '../../Services/Setor.service';
import { SetorApi } from '../../Apis/ApiSetor';
import SetorWindow from './SetorWindow';
import {SetorEmpty } from '@/app/GerAdv_TS/Models/Setor';
interface SetorWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const SetorWindowId: React.FC<SetorWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const setorService = useMemo(() => {
  return new SetorService(
  new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<ISetor | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(SetorEmpty() as ISetor);
      return;
    }
    if (id) {
      const response = await setorService.fetchSetorById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <SetorWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedSetor={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default SetorWindowId;