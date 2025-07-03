'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ForoInc from '../Crud/Inc/Foro';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ForoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ForoIncContainer: React.FC<ForoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ForoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ForoIncContainer;