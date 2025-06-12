'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import RitoInc from '../Crud/Inc/Rito';
import { getParamFromUrl } from '@/app/tools/helpers';
interface RitoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const RitoIncContainer: React.FC<RitoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <RitoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default RitoIncContainer;