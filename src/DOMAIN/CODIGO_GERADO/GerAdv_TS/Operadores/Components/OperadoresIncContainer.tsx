'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadoresInc from '../Crud/Inc/Operadores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadoresIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OperadoresIncContainer: React.FC<OperadoresIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OperadoresInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OperadoresIncContainer;