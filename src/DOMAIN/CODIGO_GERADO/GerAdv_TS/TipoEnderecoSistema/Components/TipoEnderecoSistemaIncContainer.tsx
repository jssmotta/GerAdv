'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoEnderecoSistemaInc from '../Crud/Inc/TipoEnderecoSistema';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoEnderecoSistemaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoEnderecoSistemaIncContainer: React.FC<TipoEnderecoSistemaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoEnderecoSistemaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoEnderecoSistemaIncContainer;