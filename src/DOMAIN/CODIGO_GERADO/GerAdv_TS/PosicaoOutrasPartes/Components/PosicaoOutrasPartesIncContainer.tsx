'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PosicaoOutrasPartesInc from '../Crud/Inc/PosicaoOutrasPartes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PosicaoOutrasPartesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PosicaoOutrasPartesIncContainer: React.FC<PosicaoOutrasPartesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PosicaoOutrasPartesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PosicaoOutrasPartesIncContainer;