'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import Diario2Inc from '../Crud/Inc/Diario2';
import { getParamFromUrl } from '@/app/tools/helpers';
interface Diario2IncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const Diario2IncContainer: React.FC<Diario2IncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <Diario2Inc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default Diario2IncContainer;