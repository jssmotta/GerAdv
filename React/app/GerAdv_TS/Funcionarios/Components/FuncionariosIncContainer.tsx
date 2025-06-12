'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import FuncionariosInc from '../Crud/Inc/Funcionarios';
import { getParamFromUrl } from '@/app/tools/helpers';
interface FuncionariosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const FuncionariosIncContainer: React.FC<FuncionariosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <FuncionariosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default FuncionariosIncContainer;