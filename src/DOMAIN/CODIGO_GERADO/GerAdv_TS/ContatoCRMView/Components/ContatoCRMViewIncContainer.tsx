'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContatoCRMViewInc from '../Crud/Inc/ContatoCRMView';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContatoCRMViewIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ContatoCRMViewIncContainer: React.FC<ContatoCRMViewIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ContatoCRMViewInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ContatoCRMViewIncContainer;