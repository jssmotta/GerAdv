'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import CargosEscClassInc from '../Crud/Inc/CargosEscClass';
import { getParamFromUrl } from '@/app/tools/helpers';
interface CargosEscClassIncContainerProps {
  id: number;
  navigator: INavigator;
}
const CargosEscClassIncContainer: React.FC<CargosEscClassIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <CargosEscClassInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default CargosEscClassIncContainer;