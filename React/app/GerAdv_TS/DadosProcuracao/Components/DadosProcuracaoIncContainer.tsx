'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import DadosProcuracaoInc from '../Crud/Inc/DadosProcuracao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface DadosProcuracaoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const DadosProcuracaoIncContainer: React.FC<DadosProcuracaoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <DadosProcuracaoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default DadosProcuracaoIncContainer;