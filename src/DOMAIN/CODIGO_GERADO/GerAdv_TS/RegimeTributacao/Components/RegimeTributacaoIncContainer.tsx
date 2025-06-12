'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import RegimeTributacaoInc from '../Crud/Inc/RegimeTributacao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface RegimeTributacaoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const RegimeTributacaoIncContainer: React.FC<RegimeTributacaoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <RegimeTributacaoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default RegimeTributacaoIncContainer;