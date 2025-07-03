'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import NENotasInc from '../Crud/Inc/NENotas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface NENotasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const NENotasIncContainer: React.FC<NENotasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <NENotasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default NENotasIncContainer;