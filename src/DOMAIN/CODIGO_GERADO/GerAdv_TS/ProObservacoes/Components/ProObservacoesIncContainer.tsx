'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProObservacoesInc from '../Crud/Inc/ProObservacoes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProObservacoesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProObservacoesIncContainer: React.FC<ProObservacoesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProObservacoesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProObservacoesIncContainer;