'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProValoresInc from '../Crud/Inc/ProValores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProValoresIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProValoresIncContainer: React.FC<ProValoresIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProValoresInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProValoresIncContainer;