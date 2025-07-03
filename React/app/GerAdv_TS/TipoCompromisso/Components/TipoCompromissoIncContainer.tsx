'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoCompromissoInc from '../Crud/Inc/TipoCompromisso';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoCompromissoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoCompromissoIncContainer: React.FC<TipoCompromissoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoCompromissoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoCompromissoIncContainer;