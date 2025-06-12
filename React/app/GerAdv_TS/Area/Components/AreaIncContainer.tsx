'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AreaInc from '../Crud/Inc/Area';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AreaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AreaIncContainer: React.FC<AreaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AreaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AreaIncContainer;