'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import BensClassificacaoInc from '../Crud/Inc/BensClassificacao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface BensClassificacaoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const BensClassificacaoIncContainer: React.FC<BensClassificacaoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <BensClassificacaoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default BensClassificacaoIncContainer;