'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ObjetosInc from '../Crud/Inc/Objetos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ObjetosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ObjetosIncContainer: React.FC<ObjetosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ObjetosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ObjetosIncContainer;