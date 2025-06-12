'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTPeriodicidadeStatusInc from '../Crud/Inc/GUTPeriodicidadeStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTPeriodicidadeStatusIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GUTPeriodicidadeStatusIncContainer: React.FC<GUTPeriodicidadeStatusIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GUTPeriodicidadeStatusInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GUTPeriodicidadeStatusIncContainer;