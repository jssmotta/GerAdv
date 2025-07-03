'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import HistoricoInc from '../Crud/Inc/Historico';
import { getParamFromUrl } from '@/app/tools/helpers';
interface HistoricoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const HistoricoIncContainer: React.FC<HistoricoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <HistoricoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default HistoricoIncContainer;