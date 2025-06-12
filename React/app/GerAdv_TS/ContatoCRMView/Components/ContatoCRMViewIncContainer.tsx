'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContatoCRMViewInc from '../Crud/Inc/ContatoCRMView';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContatoCRMViewIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ContatoCRMViewIncContainer: React.FC<ContatoCRMViewIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ContatoCRMViewInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ContatoCRMViewIncContainer;