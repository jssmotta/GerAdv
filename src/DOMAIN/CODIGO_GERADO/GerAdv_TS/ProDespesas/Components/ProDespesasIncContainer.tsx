'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProDespesasInc from '../Crud/Inc/ProDespesas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProDespesasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProDespesasIncContainer: React.FC<ProDespesasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProDespesasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProDespesasIncContainer;