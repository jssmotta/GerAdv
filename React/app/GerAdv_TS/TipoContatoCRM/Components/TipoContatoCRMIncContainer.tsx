'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoContatoCRMInc from '../Crud/Inc/TipoContatoCRM';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoContatoCRMIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoContatoCRMIncContainer: React.FC<TipoContatoCRMIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoContatoCRMInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoContatoCRMIncContainer;