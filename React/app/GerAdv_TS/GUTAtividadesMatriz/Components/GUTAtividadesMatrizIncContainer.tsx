'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTAtividadesMatrizInc from '../Crud/Inc/GUTAtividadesMatriz';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTAtividadesMatrizIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GUTAtividadesMatrizIncContainer: React.FC<GUTAtividadesMatrizIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GUTAtividadesMatrizInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GUTAtividadesMatrizIncContainer;