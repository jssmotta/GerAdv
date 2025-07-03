'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AtividadesInc from '../Crud/Inc/Atividades';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AtividadesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AtividadesIncContainer: React.FC<AtividadesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AtividadesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AtividadesIncContainer;