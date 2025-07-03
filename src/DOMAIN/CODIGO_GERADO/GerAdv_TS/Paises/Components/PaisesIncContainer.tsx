'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PaisesInc from '../Crud/Inc/Paises';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PaisesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PaisesIncContainer: React.FC<PaisesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PaisesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PaisesIncContainer;