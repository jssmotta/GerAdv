'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PrecatoriaInc from '../Crud/Inc/Precatoria';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PrecatoriaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PrecatoriaIncContainer: React.FC<PrecatoriaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PrecatoriaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PrecatoriaIncContainer;