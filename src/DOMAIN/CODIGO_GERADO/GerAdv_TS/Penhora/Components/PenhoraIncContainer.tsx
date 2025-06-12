'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PenhoraInc from '../Crud/Inc/Penhora';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PenhoraIncContainerProps {
  id: number;
  navigator: INavigator;
}
const PenhoraIncContainer: React.FC<PenhoraIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <PenhoraInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default PenhoraIncContainer;