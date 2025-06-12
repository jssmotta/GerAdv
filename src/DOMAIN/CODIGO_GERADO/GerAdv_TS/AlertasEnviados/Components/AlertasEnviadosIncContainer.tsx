'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AlertasEnviadosInc from '../Crud/Inc/AlertasEnviados';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AlertasEnviadosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AlertasEnviadosIncContainer: React.FC<AlertasEnviadosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AlertasEnviadosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AlertasEnviadosIncContainer;