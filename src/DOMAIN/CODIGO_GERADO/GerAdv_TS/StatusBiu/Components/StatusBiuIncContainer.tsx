'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusBiuInc from '../Crud/Inc/StatusBiu';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusBiuIncContainerProps {
  id: number;
  navigator: INavigator;
}
const StatusBiuIncContainer: React.FC<StatusBiuIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <StatusBiuInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default StatusBiuIncContainer;