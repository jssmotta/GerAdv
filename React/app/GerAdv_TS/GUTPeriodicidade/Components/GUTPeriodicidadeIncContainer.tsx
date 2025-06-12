'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTPeriodicidadeInc from '../Crud/Inc/GUTPeriodicidade';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTPeriodicidadeIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GUTPeriodicidadeIncContainer: React.FC<GUTPeriodicidadeIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GUTPeriodicidadeInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GUTPeriodicidadeIncContainer;