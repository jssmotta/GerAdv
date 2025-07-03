'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PontoVirtualAcessosInc from '../Crud/Inc/PontoVirtualAcessos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PontoVirtualAcessosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PontoVirtualAcessosIncContainer: React.FC<PontoVirtualAcessosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PontoVirtualAcessosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PontoVirtualAcessosIncContainer;