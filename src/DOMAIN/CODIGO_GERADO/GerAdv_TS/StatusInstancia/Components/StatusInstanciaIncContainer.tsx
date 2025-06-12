'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusInstanciaInc from '../Crud/Inc/StatusInstancia';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusInstanciaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const StatusInstanciaIncContainer: React.FC<StatusInstanciaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <StatusInstanciaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default StatusInstanciaIncContainer;