'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PenhoraStatusInc from '../Crud/Inc/PenhoraStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PenhoraStatusIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PenhoraStatusIncContainer: React.FC<PenhoraStatusIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PenhoraStatusInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PenhoraStatusIncContainer;