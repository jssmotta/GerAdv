'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TerceirosInc from '../Crud/Inc/Terceiros';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TerceirosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TerceirosIncContainer: React.FC<TerceirosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TerceirosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TerceirosIncContainer;