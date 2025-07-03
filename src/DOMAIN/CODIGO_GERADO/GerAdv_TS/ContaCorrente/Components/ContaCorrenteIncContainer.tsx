'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ContaCorrenteInc from '../Crud/Inc/ContaCorrente';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ContaCorrenteIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ContaCorrenteIncContainer: React.FC<ContaCorrenteIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ContaCorrenteInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ContaCorrenteIncContainer;