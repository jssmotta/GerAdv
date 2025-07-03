'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProPartesInc from '../Crud/Inc/ProPartes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProPartesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProPartesIncContainer: React.FC<ProPartesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProPartesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProPartesIncContainer;