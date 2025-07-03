'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import FornecedoresInc from '../Crud/Inc/Fornecedores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface FornecedoresIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const FornecedoresIncContainer: React.FC<FornecedoresIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <FornecedoresInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default FornecedoresIncContainer;