'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ParteClienteOutrasInc from '../Crud/Inc/ParteClienteOutras';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ParteClienteOutrasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ParteClienteOutrasIncContainer: React.FC<ParteClienteOutrasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ParteClienteOutrasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ParteClienteOutrasIncContainer;