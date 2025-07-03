'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AlarmSMSInc from '../Crud/Inc/AlarmSMS';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AlarmSMSIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AlarmSMSIncContainer: React.FC<AlarmSMSIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AlarmSMSInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AlarmSMSIncContainer;