'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContatoCRMInc from '../Crud/Inc/ContatoCRM';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContatoCRMIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ContatoCRMIncContainer: React.FC<ContatoCRMIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ContatoCRMInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ContatoCRMIncContainer;