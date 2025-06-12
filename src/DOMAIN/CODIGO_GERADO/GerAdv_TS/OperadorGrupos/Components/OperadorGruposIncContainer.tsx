'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorGruposInc from '../Crud/Inc/OperadorGrupos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorGruposIncContainerProps {
  id: number;
  navigator: INavigator;
}
const OperadorGruposIncContainer: React.FC<OperadorGruposIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <OperadorGruposInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default OperadorGruposIncContainer;