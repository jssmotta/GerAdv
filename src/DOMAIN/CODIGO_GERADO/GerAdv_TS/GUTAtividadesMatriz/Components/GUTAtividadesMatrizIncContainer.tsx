'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTAtividadesMatrizInc from '../Crud/Inc/GUTAtividadesMatriz';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTAtividadesMatrizIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GUTAtividadesMatrizIncContainer: React.FC<GUTAtividadesMatrizIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GUTAtividadesMatrizInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GUTAtividadesMatrizIncContainer;