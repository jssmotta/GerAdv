'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import FuncionariosInc from '../Crud/Inc/Funcionarios';
import { getParamFromUrl } from '@/app/tools/helpers';
interface FuncionariosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const FuncionariosIncContainer: React.FC<FuncionariosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <FuncionariosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default FuncionariosIncContainer;