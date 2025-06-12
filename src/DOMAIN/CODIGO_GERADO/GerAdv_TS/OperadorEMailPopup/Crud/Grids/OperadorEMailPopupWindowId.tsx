// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IOperadorEMailPopup } from '../../Interfaces/interface.OperadorEMailPopup';
import { OperadorEMailPopupService } from '../../Services/OperadorEMailPopup.service';
import { OperadorEMailPopupApi } from '../../Apis/ApiOperadorEMailPopup';
import OperadorEMailPopupWindow from './OperadorEMailPopupWindow';
import {OperadorEMailPopupEmpty } from '@/app/GerAdv_TS/Models/OperadorEMailPopup';
interface OperadorEMailPopupWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const OperadorEMailPopupWindowId: React.FC<OperadorEMailPopupWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const operadoremailpopupService = useMemo(() => {
  return new OperadorEMailPopupService(
  new OperadorEMailPopupApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IOperadorEMailPopup | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(OperadorEMailPopupEmpty() as IOperadorEMailPopup);
      return;
    }
    if (id) {
      const response = await operadoremailpopupService.fetchOperadorEMailPopupById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <OperadorEMailPopupWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedOperadorEMailPopup={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default OperadorEMailPopupWindowId;