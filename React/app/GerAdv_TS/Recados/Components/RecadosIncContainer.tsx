'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import RecadosInc from '../Crud/Inc/Recados';
import { getParamFromUrl } from '@/app/tools/helpers';
interface RecadosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const RecadosIncContainer: React.FC<RecadosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <RecadosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default RecadosIncContainer;