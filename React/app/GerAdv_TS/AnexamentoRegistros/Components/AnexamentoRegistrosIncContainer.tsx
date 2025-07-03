'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AnexamentoRegistrosInc from '../Crud/Inc/AnexamentoRegistros';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AnexamentoRegistrosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AnexamentoRegistrosIncContainer: React.FC<AnexamentoRegistrosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AnexamentoRegistrosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AnexamentoRegistrosIncContainer;