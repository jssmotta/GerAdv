'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ColaboradoresInc from '../Crud/Inc/Colaboradores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ColaboradoresIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ColaboradoresIncContainer: React.FC<ColaboradoresIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ColaboradoresInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ColaboradoresIncContainer;