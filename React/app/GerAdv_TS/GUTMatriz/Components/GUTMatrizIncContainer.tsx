'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTMatrizInc from '../Crud/Inc/GUTMatriz';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTMatrizIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GUTMatrizIncContainer: React.FC<GUTMatrizIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GUTMatrizInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GUTMatrizIncContainer;