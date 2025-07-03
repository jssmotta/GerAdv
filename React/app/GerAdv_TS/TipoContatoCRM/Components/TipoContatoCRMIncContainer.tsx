'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoContatoCRMInc from '../Crud/Inc/TipoContatoCRM';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoContatoCRMIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoContatoCRMIncContainer: React.FC<TipoContatoCRMIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoContatoCRMInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoContatoCRMIncContainer;