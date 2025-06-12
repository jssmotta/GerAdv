'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AtividadesInc from '../Crud/Inc/Atividades';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AtividadesIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AtividadesIncContainer: React.FC<AtividadesIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AtividadesInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AtividadesIncContainer;