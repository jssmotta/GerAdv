'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AdvogadosInc from '../Crud/Inc/Advogados';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AdvogadosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AdvogadosIncContainer: React.FC<AdvogadosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AdvogadosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AdvogadosIncContainer;