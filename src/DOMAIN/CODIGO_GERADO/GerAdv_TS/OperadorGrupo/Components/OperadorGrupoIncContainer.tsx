'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorGrupoInc from '../Crud/Inc/OperadorGrupo';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorGrupoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OperadorGrupoIncContainer: React.FC<OperadorGrupoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OperadorGrupoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OperadorGrupoIncContainer;