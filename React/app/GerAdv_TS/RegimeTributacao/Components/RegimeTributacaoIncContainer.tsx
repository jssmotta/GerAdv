'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import RegimeTributacaoInc from '../Crud/Inc/RegimeTributacao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface RegimeTributacaoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const RegimeTributacaoIncContainer: React.FC<RegimeTributacaoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <RegimeTributacaoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default RegimeTributacaoIncContainer;