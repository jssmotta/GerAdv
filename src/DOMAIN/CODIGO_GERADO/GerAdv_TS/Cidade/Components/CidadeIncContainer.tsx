'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import CidadeInc from '../Crud/Inc/Cidade';
import { getParamFromUrl } from '@/app/tools/helpers';
interface CidadeIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const CidadeIncContainer: React.FC<CidadeIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <CidadeInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default CidadeIncContainer;