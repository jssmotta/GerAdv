'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TribEnderecosInc from '../Crud/Inc/TribEnderecos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TribEnderecosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TribEnderecosIncContainer: React.FC<TribEnderecosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TribEnderecosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TribEnderecosIncContainer;