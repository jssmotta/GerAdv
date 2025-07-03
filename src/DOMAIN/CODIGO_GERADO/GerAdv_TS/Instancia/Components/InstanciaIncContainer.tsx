'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import InstanciaInc from '../Crud/Inc/Instancia';
import { getParamFromUrl } from '@/app/tools/helpers';
interface InstanciaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const InstanciaIncContainer: React.FC<InstanciaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <InstanciaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default InstanciaIncContainer;