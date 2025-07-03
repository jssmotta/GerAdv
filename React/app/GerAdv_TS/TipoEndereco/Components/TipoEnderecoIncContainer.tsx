'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoEnderecoInc from '../Crud/Inc/TipoEndereco';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoEnderecoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoEnderecoIncContainer: React.FC<TipoEnderecoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoEnderecoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoEnderecoIncContainer;