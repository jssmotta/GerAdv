'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorGruposInc from '../Crud/Inc/OperadorGrupos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorGruposIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OperadorGruposIncContainer: React.FC<OperadorGruposIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OperadorGruposInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OperadorGruposIncContainer;