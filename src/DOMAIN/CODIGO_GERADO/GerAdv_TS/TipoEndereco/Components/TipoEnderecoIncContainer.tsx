'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoEnderecoInc from '../Crud/Inc/TipoEndereco';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoEnderecoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoEnderecoIncContainer: React.FC<TipoEnderecoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoEnderecoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoEnderecoIncContainer;