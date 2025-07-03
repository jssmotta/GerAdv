'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import UltimosProcessosInc from '../Crud/Inc/UltimosProcessos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface UltimosProcessosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const UltimosProcessosIncContainer: React.FC<UltimosProcessosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <UltimosProcessosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default UltimosProcessosIncContainer;