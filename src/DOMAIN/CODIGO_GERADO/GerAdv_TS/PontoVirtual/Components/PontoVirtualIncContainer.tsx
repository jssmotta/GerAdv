'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PontoVirtualInc from '../Crud/Inc/PontoVirtual';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PontoVirtualIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PontoVirtualIncContainer: React.FC<PontoVirtualIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PontoVirtualInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PontoVirtualIncContainer;