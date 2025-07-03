'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AreasJusticaInc from '../Crud/Inc/AreasJustica';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AreasJusticaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AreasJusticaIncContainer: React.FC<AreasJusticaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AreasJusticaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AreasJusticaIncContainer;