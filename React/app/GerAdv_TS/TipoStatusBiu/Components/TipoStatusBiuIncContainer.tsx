'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoStatusBiuInc from '../Crud/Inc/TipoStatusBiu';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoStatusBiuIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoStatusBiuIncContainer: React.FC<TipoStatusBiuIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoStatusBiuInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoStatusBiuIncContainer;