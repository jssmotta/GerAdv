'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AndCompInc from '../Crud/Inc/AndComp';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AndCompIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AndCompIncContainer: React.FC<AndCompIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AndCompInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AndCompIncContainer;