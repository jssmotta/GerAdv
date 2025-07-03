'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TribunalInc from '../Crud/Inc/Tribunal';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TribunalIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TribunalIncContainer: React.FC<TribunalIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TribunalInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TribunalIncContainer;