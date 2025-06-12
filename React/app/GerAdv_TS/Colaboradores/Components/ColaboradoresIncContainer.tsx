'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ColaboradoresInc from '../Crud/Inc/Colaboradores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ColaboradoresIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ColaboradoresIncContainer: React.FC<ColaboradoresIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ColaboradoresInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ColaboradoresIncContainer;