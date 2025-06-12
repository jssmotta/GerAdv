'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PenhoraStatusInc from '../Crud/Inc/PenhoraStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PenhoraStatusIncContainerProps {
  id: number;
  navigator: INavigator;
}
const PenhoraStatusIncContainer: React.FC<PenhoraStatusIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <PenhoraStatusInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default PenhoraStatusIncContainer;