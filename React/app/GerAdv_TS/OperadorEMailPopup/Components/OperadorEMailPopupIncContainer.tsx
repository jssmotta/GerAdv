'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorEMailPopupInc from '../Crud/Inc/OperadorEMailPopup';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorEMailPopupIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OperadorEMailPopupIncContainer: React.FC<OperadorEMailPopupIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OperadorEMailPopupInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OperadorEMailPopupIncContainer;