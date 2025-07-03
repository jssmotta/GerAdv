'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ApensoInc from '../Crud/Inc/Apenso';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ApensoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ApensoIncContainer: React.FC<ApensoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ApensoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ApensoIncContainer;