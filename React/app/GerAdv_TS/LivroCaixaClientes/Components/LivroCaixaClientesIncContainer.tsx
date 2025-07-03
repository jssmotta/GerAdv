'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import LivroCaixaClientesInc from '../Crud/Inc/LivroCaixaClientes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface LivroCaixaClientesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const LivroCaixaClientesIncContainer: React.FC<LivroCaixaClientesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <LivroCaixaClientesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default LivroCaixaClientesIncContainer;