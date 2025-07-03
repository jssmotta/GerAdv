'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTAtividadesInc from '../Crud/Inc/GUTAtividades';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTAtividadesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GUTAtividadesIncContainer: React.FC<GUTAtividadesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GUTAtividadesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GUTAtividadesIncContainer;