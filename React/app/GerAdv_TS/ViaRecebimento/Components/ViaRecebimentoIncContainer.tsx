'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ViaRecebimentoInc from '../Crud/Inc/ViaRecebimento';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ViaRecebimentoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ViaRecebimentoIncContainer: React.FC<ViaRecebimentoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ViaRecebimentoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ViaRecebimentoIncContainer;