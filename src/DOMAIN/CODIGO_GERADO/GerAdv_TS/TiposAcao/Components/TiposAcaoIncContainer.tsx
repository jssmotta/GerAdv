'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TiposAcaoInc from '../Crud/Inc/TiposAcao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TiposAcaoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TiposAcaoIncContainer: React.FC<TiposAcaoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TiposAcaoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TiposAcaoIncContainer;