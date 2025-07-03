'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PenhoraInc from '../Crud/Inc/Penhora';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PenhoraIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const PenhoraIncContainer: React.FC<PenhoraIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <PenhoraInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default PenhoraIncContainer;