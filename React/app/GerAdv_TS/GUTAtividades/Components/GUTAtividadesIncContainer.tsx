'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTAtividadesInc from '../Crud/Inc/GUTAtividades';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTAtividadesIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GUTAtividadesIncContainer: React.FC<GUTAtividadesIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GUTAtividadesInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GUTAtividadesIncContainer;