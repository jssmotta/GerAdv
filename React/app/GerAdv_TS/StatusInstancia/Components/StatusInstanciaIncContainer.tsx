'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusInstanciaInc from '../Crud/Inc/StatusInstancia';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusInstanciaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const StatusInstanciaIncContainer: React.FC<StatusInstanciaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <StatusInstanciaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default StatusInstanciaIncContainer;