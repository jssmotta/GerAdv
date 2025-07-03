'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoStatusBiuInc from '../Crud/Inc/TipoStatusBiu';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoStatusBiuIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoStatusBiuIncContainer: React.FC<TipoStatusBiuIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoStatusBiuInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoStatusBiuIncContainer;