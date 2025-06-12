'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PontoVirtualAcessosInc from '../Crud/Inc/PontoVirtualAcessos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PontoVirtualAcessosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const PontoVirtualAcessosIncContainer: React.FC<PontoVirtualAcessosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <PontoVirtualAcessosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default PontoVirtualAcessosIncContainer;