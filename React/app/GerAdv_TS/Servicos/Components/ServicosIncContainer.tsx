'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ServicosInc from '../Crud/Inc/Servicos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ServicosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ServicosIncContainer: React.FC<ServicosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ServicosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ServicosIncContainer;