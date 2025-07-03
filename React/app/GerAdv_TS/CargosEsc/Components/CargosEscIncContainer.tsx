'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import CargosEscInc from '../Crud/Inc/CargosEsc';
import { getParamFromUrl } from '@/app/tools/helpers';
interface CargosEscIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const CargosEscIncContainer: React.FC<CargosEscIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <CargosEscInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default CargosEscIncContainer;