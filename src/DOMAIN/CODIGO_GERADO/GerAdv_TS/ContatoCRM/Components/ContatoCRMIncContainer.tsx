'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContatoCRMInc from '../Crud/Inc/ContatoCRM';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContatoCRMIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ContatoCRMIncContainer: React.FC<ContatoCRMIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ContatoCRMInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ContatoCRMIncContainer;