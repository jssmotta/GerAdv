'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoProDespositoInc from '../Crud/Inc/TipoProDesposito';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoProDespositoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoProDespositoIncContainer: React.FC<TipoProDespositoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoProDespositoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoProDespositoIncContainer;