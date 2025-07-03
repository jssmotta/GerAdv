'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusHTrabInc from '../Crud/Inc/StatusHTrab';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusHTrabIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const StatusHTrabIncContainer: React.FC<StatusHTrabIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <StatusHTrabInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default StatusHTrabIncContainer;