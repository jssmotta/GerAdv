// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IAlarmSMS } from '../../Interfaces/interface.AlarmSMS';
import { AlarmSMSService } from '../../Services/AlarmSMS.service';
import { AlarmSMSApi } from '../../Apis/ApiAlarmSMS';
import AlarmSMSWindow from './AlarmSMSWindow';
import {AlarmSMSEmpty } from '@/app/GerAdv_TS/Models/AlarmSMS';
interface AlarmSMSWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const AlarmSMSWindowId: React.FC<AlarmSMSWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const alarmsmsService = useMemo(() => {
  return new AlarmSMSService(
  new AlarmSMSApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IAlarmSMS | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(AlarmSMSEmpty() as IAlarmSMS);
      return;
    }
    if (id) {
      const response = await alarmsmsService.fetchAlarmSMSById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <AlarmSMSWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedAlarmSMS={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default AlarmSMSWindowId;