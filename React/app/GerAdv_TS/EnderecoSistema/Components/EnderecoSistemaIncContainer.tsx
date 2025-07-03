'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EnderecoSistemaInc from '../Crud/Inc/EnderecoSistema';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EnderecoSistemaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const EnderecoSistemaIncContainer: React.FC<EnderecoSistemaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <EnderecoSistemaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default EnderecoSistemaIncContainer;