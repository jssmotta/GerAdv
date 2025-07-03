'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTPeriodicidadeStatusInc from '../Crud/Inc/GUTPeriodicidadeStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTPeriodicidadeStatusIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GUTPeriodicidadeStatusIncContainer: React.FC<GUTPeriodicidadeStatusIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GUTPeriodicidadeStatusInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GUTPeriodicidadeStatusIncContainer;