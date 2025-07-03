'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoProDespositoInc from '../Crud/Inc/TipoProDesposito';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoProDespositoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoProDespositoIncContainer: React.FC<TipoProDespositoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoProDespositoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoProDespositoIncContainer;