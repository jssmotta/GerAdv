'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import RamalInc from '../Crud/Inc/Ramal';
import { getParamFromUrl } from '@/app/tools/helpers';
interface RamalIncContainerProps {
  id: number;
  navigator: INavigator;
}
const RamalIncContainer: React.FC<RamalIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <RamalInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default RamalIncContainer;