'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContaCorrenteInc from '../Crud/Inc/ContaCorrente';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContaCorrenteIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ContaCorrenteIncContainer: React.FC<ContaCorrenteIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ContaCorrenteInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ContaCorrenteIncContainer;