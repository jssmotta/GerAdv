'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadoresInc from '../Crud/Inc/Operadores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadoresIncContainerProps {
  id: number;
  navigator: INavigator;
}
const OperadoresIncContainer: React.FC<OperadoresIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <OperadoresInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default OperadoresIncContainer;