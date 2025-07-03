'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import SMSAliceInc from '../Crud/Inc/SMSAlice';
import { getParamFromUrl } from '@/app/tools/helpers';
interface SMSAliceIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const SMSAliceIncContainer: React.FC<SMSAliceIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <SMSAliceInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default SMSAliceIncContainer;