'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AlertasInc from '../Crud/Inc/Alertas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AlertasIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AlertasIncContainer: React.FC<AlertasIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AlertasInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AlertasIncContainer;