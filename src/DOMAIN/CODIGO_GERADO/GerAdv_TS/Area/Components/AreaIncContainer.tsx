'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AreaInc from '../Crud/Inc/Area';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AreaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AreaIncContainer: React.FC<AreaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AreaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AreaIncContainer;