'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PrecatoriaInc from '../Crud/Inc/Precatoria';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PrecatoriaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const PrecatoriaIncContainer: React.FC<PrecatoriaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <PrecatoriaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default PrecatoriaIncContainer;