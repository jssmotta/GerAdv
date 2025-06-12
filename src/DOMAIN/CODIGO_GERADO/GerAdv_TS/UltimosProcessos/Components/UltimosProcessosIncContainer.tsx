'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import UltimosProcessosInc from '../Crud/Inc/UltimosProcessos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface UltimosProcessosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const UltimosProcessosIncContainer: React.FC<UltimosProcessosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <UltimosProcessosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default UltimosProcessosIncContainer;