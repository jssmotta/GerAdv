'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import DadosProcuracaoInc from '../Crud/Inc/DadosProcuracao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface DadosProcuracaoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const DadosProcuracaoIncContainer: React.FC<DadosProcuracaoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <DadosProcuracaoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default DadosProcuracaoIncContainer;