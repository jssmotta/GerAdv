'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProCDAInc from '../Crud/Inc/ProCDA';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProCDAIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProCDAIncContainer: React.FC<ProCDAIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProCDAInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProCDAIncContainer;