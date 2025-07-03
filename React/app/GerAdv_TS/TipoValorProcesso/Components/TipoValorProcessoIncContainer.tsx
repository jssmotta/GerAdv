'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoValorProcessoInc from '../Crud/Inc/TipoValorProcesso';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoValorProcessoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoValorProcessoIncContainer: React.FC<TipoValorProcessoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoValorProcessoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoValorProcessoIncContainer;