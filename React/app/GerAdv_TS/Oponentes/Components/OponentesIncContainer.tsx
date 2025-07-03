'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OponentesInc from '../Crud/Inc/Oponentes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OponentesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OponentesIncContainer: React.FC<OponentesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OponentesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OponentesIncContainer;