'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusBiuInc from '../Crud/Inc/StatusBiu';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusBiuIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const StatusBiuIncContainer: React.FC<StatusBiuIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <StatusBiuInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default StatusBiuIncContainer;