'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import FaseInc from '../Crud/Inc/Fase';
import { getParamFromUrl } from '@/app/tools/helpers';
interface FaseIncContainerProps {
  id: number;
  navigator: INavigator;
}
const FaseIncContainer: React.FC<FaseIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <FaseInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default FaseIncContainer;