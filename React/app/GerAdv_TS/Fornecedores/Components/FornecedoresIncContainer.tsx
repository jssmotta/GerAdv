'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import FornecedoresInc from '../Crud/Inc/Fornecedores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface FornecedoresIncContainerProps {
  id: number;
  navigator: INavigator;
}
const FornecedoresIncContainer: React.FC<FornecedoresIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <FornecedoresInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default FornecedoresIncContainer;