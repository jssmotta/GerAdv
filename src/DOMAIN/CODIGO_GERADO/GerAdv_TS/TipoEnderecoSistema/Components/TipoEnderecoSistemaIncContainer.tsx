'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoEnderecoSistemaInc from '../Crud/Inc/TipoEnderecoSistema';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoEnderecoSistemaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoEnderecoSistemaIncContainer: React.FC<TipoEnderecoSistemaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoEnderecoSistemaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoEnderecoSistemaIncContainer;