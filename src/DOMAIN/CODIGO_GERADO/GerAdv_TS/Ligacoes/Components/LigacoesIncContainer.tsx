'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import LigacoesInc from '../Crud/Inc/Ligacoes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface LigacoesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const LigacoesIncContainer: React.FC<LigacoesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <LigacoesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default LigacoesIncContainer;