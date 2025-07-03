'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import CargosInc from '../Crud/Inc/Cargos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface CargosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const CargosIncContainer: React.FC<CargosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <CargosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default CargosIncContainer;