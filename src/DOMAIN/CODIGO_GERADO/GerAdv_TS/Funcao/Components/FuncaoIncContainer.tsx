'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import FuncaoInc from '../Crud/Inc/Funcao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface FuncaoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const FuncaoIncContainer: React.FC<FuncaoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <FuncaoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default FuncaoIncContainer;