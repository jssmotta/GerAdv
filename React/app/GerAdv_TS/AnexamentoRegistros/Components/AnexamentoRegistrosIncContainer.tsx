'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AnexamentoRegistrosInc from '../Crud/Inc/AnexamentoRegistros';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AnexamentoRegistrosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AnexamentoRegistrosIncContainer: React.FC<AnexamentoRegistrosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AnexamentoRegistrosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AnexamentoRegistrosIncContainer;