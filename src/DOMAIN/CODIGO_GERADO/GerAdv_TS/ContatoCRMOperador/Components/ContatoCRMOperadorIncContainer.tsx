'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContatoCRMOperadorInc from '../Crud/Inc/ContatoCRMOperador';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContatoCRMOperadorIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ContatoCRMOperadorIncContainer: React.FC<ContatoCRMOperadorIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ContatoCRMOperadorInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ContatoCRMOperadorIncContainer;